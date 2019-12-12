using System;
using System.Linq;
using SuperSocket.ProtoBase;

namespace NcsChatClient
{
    public class NcsReceiveFilter : FixedHeaderReceiveFilter<NcsRequestInfo>
    {
        public NcsReceiveFilter() : base(6)
        {

        }

        public override NcsRequestInfo ResolvePackage(IBufferStream bufferStream)
        {
            byte[] header = bufferStream.Buffers[0].ToArray();
            byte[] bodyBuffer = bufferStream.Buffers[1].ToArray();
            var package = new NcsRequestInfo(header, bodyBuffer);
            return package;
        }

        protected override int GetBodyLengthFromHeader(IBufferStream bufferStream, int length)
        {
            ArraySegment<byte> buffers = bufferStream.Buffers[0];
            byte[] array = buffers.ToArray();
            return BitConverter.ToInt32(array, 0) - 6; ;
        }
    }
}