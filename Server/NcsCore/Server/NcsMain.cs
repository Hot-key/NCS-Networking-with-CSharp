using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGD;
using NcsCore.Routing;
using NcsCore;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;

namespace NcsCore.Server
{
    public class NcsMain<T> where T : AppSession<T, NcsRequestInfo>, new()
    {
        NcsServer<T> ncsServer = new NcsServer<T>();

        public NcsMain(ServerConfig config)
        {
            NcsScan.StartScan();
            NcsDefine.Option = new NcsOption();
            ncsServer.Setup(new RootConfig(), config);
            ncsServer.Start();

            ncsServer.NewSessionConnected += new SessionHandler<T>(NcsServer_NewUserConnected);
            ncsServer.SessionClosed += new SessionHandler<T, CloseReason>(NcsServer_UserClosed);
            ncsServer.NewRequestReceived += new RequestHandler<T, NcsRequestInfo>(NcsServer_NewRequestReceived);
        }

        public NcsMain(ServerConfig config, NcsOption option)
        {
            NcsScan.StartScan();
            NcsDefine.Option = option;
            ncsServer.Setup(new RootConfig(), config);
            ncsServer.Start();

            ncsServer.NewSessionConnected += new SessionHandler<T>(NcsServer_NewUserConnected);
            ncsServer.SessionClosed += new SessionHandler<T, CloseReason>(NcsServer_UserClosed);
            ncsServer.NewRequestReceived += new RequestHandler<T, NcsRequestInfo>(NcsServer_NewRequestReceived);
        }

        void NcsServer_NewUserConnected(T user)
        {
            NcsModule<T>.NewSessionConnected.Invoke(user);
        }

        void NcsServer_UserClosed(T user, CloseReason reason)
        {
            NcsModule<T>.SessionClosed.Invoke(user, reason);
        }

        void NcsServer_NewRequestReceived(T user, NcsRequestInfo requestInfo)
        {

            NcsModule<T>.NewRequestReceived(user, requestInfo);
            if (Packet<T>.BufferDictionary.ContainsKey(requestInfo.Key))
            {
                Packet<T>.BufferDictionary[requestInfo.Key](user, requestInfo);
            }

            requestInfo.Clear();
            NcsRequestInfo.RequestInfoPool.PutObject(requestInfo);
        }

    }
}
