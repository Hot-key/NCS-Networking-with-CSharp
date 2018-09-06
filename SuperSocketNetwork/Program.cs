using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;

namespace SuperSocketNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerConfig mConfig = new ServerConfig()
            {
                Port = 7979,
                Ip = "Any",
                MaxConnectionNumber = 10000,
                Mode = SocketMode.Tcp,
                Name = "MainServer"
            };

            NCSServer mServer = new NCSServer();
            mServer.Setup(new RootConfig(), mConfig);
        }
    }

    public class NCSSession : AppSession<NCSSession>
    {
        public string Pid =  String.Empty;
        protected override void OnSessionStarted()
        {
            base.OnSessionStarted();
        }

        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            this.Send("Unknown request");
        }

        protected override void HandleException(Exception e)
        {
            this.Send("Application error: {0}", e.Message);
        }

        protected override void OnSessionClosed(CloseReason reason)
        {
            base.OnSessionClosed(reason);
        }
    }

    class NCSServer : AppServer<NCSSession>
    {
        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            return base.Setup(rootConfig, config);
        }

        protected override void OnStopped()
        {
            base.OnStopped();
        }
    }

    public class Login : CommandBase<NCSSession, StringRequestInfo>
    {
        public override void ExecuteCommand(NCSSession session, StringRequestInfo requestInfo)
        {

        }
    }
}
