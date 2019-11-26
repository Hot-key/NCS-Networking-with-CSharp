using System;
using System.Threading.Tasks;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace NcsCore.Server
{
    public class NcsUser<T> : AppSession<T, NcsRequestInfo> where T : AppSession<T, NcsRequestInfo>, new()
    {
        ///  Override Functions
        protected override void OnSessionStarted()
        {
            base.OnSessionStarted();
        }

        protected override void HandleException(Exception e)
        {
            Console.WriteLine("Application error: {0}", e.Message);
        }

        protected override void OnSessionClosed(CloseReason reason)
        {
            base.OnSessionClosed(reason);
        }

        public void Send(CGD.NcsBuffer buffer)
        {
            this.Send(buffer.buf, 0, buffer.len);
        }
    }

    public class NetworkSession : AppSession<NetworkSession, BinaryRequestInfo>
    {
        public void Send(CGD.NcsBuffer buffer)
        {
            this.Send(buffer.buf, 0, buffer.len);
        }
    }
}