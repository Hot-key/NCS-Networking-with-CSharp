using NcsCore.Pool;
using SuperSocket.SocketBase.Protocol;

namespace NcsCore.Server
{
    public class NcsRequestInfo : RequestInfo<NcsRequestInfo>
    {
        public static NcsObjectPool<NcsRequestInfo> RequestInfoPool = new NcsObjectPool<NcsRequestInfo>(null);

        public new dynamic Key { get; private set; }

        public new CGD.NcsBuffer Body { get; private set; }


        public NcsRequestInfo(byte[] body, byte[] buffer)
        {
            Key = NcsDefine.Option.TypeFunc(new CGD.NcsBuffer(buffer, 0, buffer.Length));
            Body = new CGD.NcsBuffer(body, 0, body.Length);
        }

        public NcsRequestInfo()
        {
        }

        public NcsRequestInfo SetBuffer(byte[] body)
        {
            Key = NcsDefine.Option.TypeFunc(new CGD.NcsBuffer(body, 0, body.Length));
            Body = new CGD.NcsBuffer(body, 0, body.Length);

            return this;
        }
        public NcsRequestInfo SetBuffer(byte[] body,int length)
        {
            Key = NcsDefine.Option.TypeFunc(new CGD.NcsBuffer(body, 0, length));
            Body = new CGD.NcsBuffer(body, 0, length);

            return this;
        }

        public void Clear()
        {
            Key = null;
            NcsPool.ReturnBuffer(Body.clear());
        }
    }
}