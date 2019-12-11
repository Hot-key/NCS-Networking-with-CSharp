using SuperSocket.ProtoBase;

namespace NcsChatClient
{
    public class NcsRequestInfo : IPackageInfo
    {

        public new dynamic Key { get; private set; }

        public new CGD.NcsBuffer Body { get; private set; }


        public NcsRequestInfo(byte[] body, byte[] buffer)
        {
            Key = new CGD.NcsBuffer(buffer, 0, buffer.Length).get_front_ushort(4);
            Body = new CGD.NcsBuffer(body, 0, body.Length);
        }
    }
}