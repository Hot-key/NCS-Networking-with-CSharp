using System;
using NcsCore.Function;
using NcsCore.Pool;
using SuperSocket.Common;
using SuperSocket.SocketEngine.Protocol;

namespace NcsCore.Server
{
    public class NcsReceiveFilter : FixedHeaderReceiveFilter<NcsRequestInfo>
    { 
        public NcsReceiveFilter() : base(NcsDefine.Option.HeaderSize)
        {

        }

        protected override int GetBodyLengthFromHeader(byte[] header, int offset, int length)
        {
            //if (!BitConverter.IsLittleEndian)
            //{
            //    Array.Reverse(header, offset, 2);
            //}

            return NcsDefine.Option.ReceiveFunc(header, offset, length) - NcsDefine.Option.HeaderSize;
        }

        protected override NcsRequestInfo ResolveRequestInfo(ArraySegment<byte> header, byte[] bodyBuffer, int offset, int length)
        {
            //if (!BitConverter.IsLittleEndian)
            //{
            //    Array.Reverse(header.Array, offset, 2);
            //}

            var byteTmp = bodyBuffer.CloneRange(offset, length);
            return NcsRequestInfo.RequestInfoPool.GetObject().SetBuffer(ByteFunction.Combine(header.Array, byteTmp), length + NcsDefine.Option.HeaderSize);
        }
    }
}