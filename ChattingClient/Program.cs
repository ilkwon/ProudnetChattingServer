// Program.cs
using Nettention.Proud;
using ChattingCommon;

namespace Client
{
    class Program
    {
        static object cs = new object();
        static NetClient netClient = new NetClient();
        static S2C.Stub S2CStub = new S2C.Stub();
        static C2S.Proxy C2SProxy = new C2S.Proxy();
        static bool isConnected = false;
        static bool keepWorkerThread = true;

        static bool isLoggedIn = false;
        static User me = new User();
        static void InitializeStub()
        {
            S2CStub.SystemChat = (Nettention.Proud.HostID remote, Nettention.Proud.RmiContext rmiContext, string str) => 
            {
                lock (cs)
                {
                    Console.WriteLine("[System] {0}", str);
                }
                return true; 
            };

            S2CStub.NotifyChat = (Nettention.Proud.HostID remote, Nettention.Proud.RmiContext rmiContext, string userName, string str) =>
            {
                lock (cs)
                {
                    Console.WriteLine("{0}: {1}", userName, str);
                }
                return true;
            };

            S2CStub.ResponseLogin = (Nettention.Proud.HostID remote, Nettention.Proud.RmiContext rmiContext, User user) => 
            {
                lock (cs) 
                {
                    isLoggedIn = true;
                    me = user;
                }

                return true;
            };

            S2CStub.ResponseLogout = (Nettention.Proud.HostID remote, Nettention.Proud.RmiContext rmiContext, User user) =>
            {
                lock (cs)
                {                    
                    keepWorkerThread = false;
                }

                return true;
            };
        }

        static void InitializeHandler()
        {
            netClient.JoinServerCompleteHandler = (info, replyFromServer) =>
            {
                lock (cs)
                {
                    if (info.errorType == ErrorType.ErrorType_Ok)
                    {
                        Console.Write("Succeed to connect server. Allocated hostId={0}\n", netClient.GetLocalHostID());
                        isConnected = true;
                    }
                    else
                    {
                        Console.Write("Failed to connect server.\n");
                        Console.WriteLine("errorType = {0}, detailType = {1}, comment = {2}", info.errorType, info.detailType, info.comment);
                    }
                }
            };

            netClient.LeaveServerHandler = (errorInfo) =>
            {
                lock (cs)
                {
                    Console.Write("OnLeaveServer: {0}\n", errorInfo.comment);

                    isConnected = false;
                    keepWorkerThread = false;
                }
            };
        }

        static void InitializeClient()
        {
            netClient.AttachStub(S2CStub);
            netClient.AttachProxy(C2SProxy);
        }

        static void InitializeClientParamter()
        {
            NetConnectionParam cp = new NetConnectionParam();
            cp.protocolVersion.Set(Vars.m_Version);
            cp.serverIP = "127.0.0.1";
            cp.serverPort = (ushort)Vars.m_serverPort;
            netClient.Connect(cp);
        }

        static void Main(string[] args)
        {
            InitializeHandler();
            InitializeClient();
            InitializeStub();
            InitializeClientParamter();

            Thread workerThread = new Thread(() =>
            {
                while(keepWorkerThread)
                {
                    Thread.Sleep(10);
                    netClient.FrameMove();
                }
            });

            workerThread.Start();

            while (!isConnected)
                Thread.Sleep(1000);
            Console.Write("UserName :");
            
            while(keepWorkerThread)
            {
                string userInput = Console.ReadLine();
                if (userInput == "") 
                    continue;

                if (isLoggedIn)
                {
                    if (userInput == "q")
                    {
                        keepWorkerThread = false;                        
                    }
                    else if (userInput == "logout")
                    {
                        isLoggedIn = false;
                        C2SProxy.Logout(HostID.HostID_Server, RmiContext.ReliableSend);
                    }
                    else if (userInput == "count")
                    {
                        
                    }
                    else
                        C2SProxy.Chat(HostID.HostID_Server, RmiContext.ReliableSend, userInput);
                }
                else
                {
                    C2SProxy.Login(HostID.HostID_Server, RmiContext.ReliableSend, userInput);
                }
            }
            
            //C2SProxy.Logout(HostID.HostID_Server, RmiContext.ReliableSend);
            workerThread.Join();
            netClient.Disconnect();
        }
    }
}