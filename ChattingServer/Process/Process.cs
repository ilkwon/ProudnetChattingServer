using ChattingCommon;
using Nettention.Proud;

namespace ChattingServer.process
{
    internal class CommonProcess
    {
        static S2C.Proxy S2CProxy = new S2C.Proxy();
        static C2S.Stub C2SStub = new C2S.Stub();

        public void InitStub()
        {
            C2SStub.Chat = Chat;
            C2SStub.Login = Login;
            C2SStub.Logout = Logout;

            ServerLauncher.NetServer.AttachProxy(S2CProxy);
            ServerLauncher.NetServer.AttachStub(C2SStub);
        }

        static public bool Chat(Nettention.Proud.HostID remote, Nettention.Proud.RmiContext rmiContext, string str)
        {
            //User user = new User();
            ServerLauncher.Users.TryGetValue(remote, out User user);
            Console.WriteLine("{0}:{1}", user.UserName, str);
            S2CProxy.NotifyChat(ServerLauncher.NetServer.GetClientHostIDs(), rmiContext, user.UserName, str);

            return true;
        }

        private bool Login(HostID remote, RmiContext rmiContext, string userName)
        {
            string message = string.Format("{0}: entered.", userName);

            // 새 User 추가.
            User user = new User(userName, remote);
            // User 등록.
            ServerLauncher.Users.TryAdd(remote, user);
            // 로그인된 유저 처리 및 메시지 전송
            S2CProxy.ResponseLogin(user.HostId, rmiContext, user);
            S2CProxy.SystemChat(ServerLauncher.NetServer.GetClientHostIDs(), RmiContext.ReliableSend, message);

            Console.WriteLine(message);
            return true;
        }

        private bool Logout(HostID remote, RmiContext rmiContext)
        {

            ServerLauncher.Users.TryRemove(remote, out User user);
            string message = string.Format("{0}: logout and rmoved user. User Count:{1}", user.UserName, ServerLauncher.Users.Count);
            
            S2CProxy.SystemChat(ServerLauncher.NetServer.GetClientHostIDs(), RmiContext.ReliableSend, message);
            S2CProxy.ResponseLogout(user.HostId, rmiContext, user);
            
            Console.WriteLine(message);
            
            return true;            
        }

        public void SystemChat(string str)
        {
            S2CProxy.SystemChat(ServerLauncher.NetServer.GetClientHostIDs(), RmiContext.ReliableSend, str);
        }
    }
}
