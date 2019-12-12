using System;
using CGD;
using SuperSocket.ProtoBase;

namespace NcsChatClient
{
    public class NcsRequestInfo : IPackageInfo
    {

        public dynamic Key { get; private set; }

        public CGD.NcsBuffer Body { get; private set; }

        public NcsBuffer RecvData { get; private set; }

        public NcsRequestInfo(byte[] header, byte[] body)
        {
            Key = new CGD.NcsBuffer(header, 0, header.Length).get_front_ushort(4);
            Body = new CGD.NcsBuffer(body, 0, body.Length);
            RecvData = new CGD.NcsBuffer(Combine(header, body));
        }

        public static byte[] Combine(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }
    }
}