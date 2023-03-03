using ChattingCommon;
using Nettention.Proud;
using System.Collections.Concurrent;

namespace ChattingServer
{
    internal class ServerLauncher
    {
        public bool runLoop;
        public static readonly NetServer NetServer = new NetServer();

        public static ConcurrentDictionary<HostID, User> Users { get; } = new ConcurrentDictionary<HostID, User>();
        Handler Handler = new Handler();
        process.CommonProcess Process = new process.CommonProcess();

        //---------------------------------------------------------------------
        public void InitializeStub()
        {
            Process.InitStub();
        }

        //---------------------------------------------------------------------
        public void InitializeHandler()
        {
            NetServer.ConnectionRequestHandler = Handler.ConnectionRequestHandler;
            NetServer.ClientHackSuspectedHandler = Handler.ClientHackSuspectedHandler;
            NetServer.ClientJoinHandler = Handler.ClientJoinHandler;
            NetServer.ClientLeaveHandler = Handler.ClientLeaveHandler;
            NetServer.ErrorHandler = Handler.ErrorHandler;
            NetServer.WarningHandler = Handler.WarningHandler;
            NetServer.ExceptionHandler = Handler.ExceptionHandler;
            NetServer.InformationHandler = Handler.InfomationHandler;
            NetServer.NoRmiProcessedHandler = Handler.NoRmiProcessedHandler;
            NetServer.P2PGroupJoinMemberAckCompleteHandler = Handler.P2PGroupJoinMemberAckCompleteHandler;
            NetServer.TickHandler = Handler.TickHandler;
            NetServer.UserWorkerThreadBeginHandler = Handler.UserWorkerThreadBeginHandler;
            NetServer.UserWorkerThreadEndHandler = Handler.UserWorkerThreadEndHandler;
        }

        //---------------------------------------------------------------------
        public void InitializeServerParameter() 
        {
            var parameter = new StartServerParameter();
            parameter.protocolVersion = new Nettention.Proud.Guid(Vars.m_Version);
            parameter.tcpPorts.Add(Vars.m_serverPort);
            NetServer.Start(parameter);
        }

        //---------------------------------------------------------------------
        public void ServerStart()
        {
            InitializeHandler();
            InitializeStub();
            InitializeServerParameter();
            runLoop = true;
        }

        //---------------------------------------------------------------------
        public void Dispose()
        {
            NetServer.Dispose();
        }
    }
}
