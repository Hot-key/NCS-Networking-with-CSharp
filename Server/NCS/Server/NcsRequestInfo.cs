using SuperSocket.SocketBase.Protocol;

namespace Ncs.Server
{
    public class NcsRequestInfo : RequestInfo<NcsRequestInfo>
    {
        public int offset = 0;

        public new dynamic Key { get; private set; }

        public new byte[] Body { get; private set; }

        public CGD.buffer Buffer { get; private set; }

        public NcsRequestInfo(byte[] body, byte[] buffer)
        {
            Key = NcsDefine.Option.TypeFunc(new CGD.buffer(buffer, 0, buffer.Length));
            this.Body = body;
            Buffer = new CGD.buffer(buffer, 0, buffer.Length);
        }

        public NcsRequestInfo()
        {
        }

        public NcsRequestInfo SetBuffer(byte[] body, byte[] buffer)
        {
            Key = NcsDefine.Option.TypeFunc(new CGD.buffer(buffer, 0, buffer.Length));
            this.Body = body;
            Buffer = new CGD.buffer(buffer, 0, buffer.Length);

            return this;
        }
    }
}