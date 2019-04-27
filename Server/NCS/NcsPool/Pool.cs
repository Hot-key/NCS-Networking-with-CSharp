using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ncs.Server;

namespace Ncs.NcsPool
{
    internal static class Pool
    {
        public static NcsObjectPool<NcsRequestInfo> RequestInfoPool = new NcsObjectPool<NcsRequestInfo>(() => new NcsRequestInfo());

        private static NcsObjectPool<CGD.buffer> BufferPool16 = new NcsObjectPool<CGD.buffer>(() => new CGD.buffer(16));
        private static NcsObjectPool<CGD.buffer> BufferPool32 = new NcsObjectPool<CGD.buffer>(() => new CGD.buffer(32));
        private static NcsObjectPool<CGD.buffer> BufferPool64 = new NcsObjectPool<CGD.buffer>(() => new CGD.buffer(64));
        private static NcsObjectPool<CGD.buffer> BufferPool128 = new NcsObjectPool<CGD.buffer>(() => new CGD.buffer(128));
        private static NcsObjectPool<CGD.buffer> BufferPool256 = new NcsObjectPool<CGD.buffer>(() => new CGD.buffer(256));
        private static NcsObjectPool<CGD.buffer> BufferPool518 = new NcsObjectPool<CGD.buffer>(() => new CGD.buffer(518));
        private static NcsObjectPool<CGD.buffer> BufferPool1024 = new NcsObjectPool<CGD.buffer>(() => new CGD.buffer(1024));
        private static NcsObjectPool<CGD.buffer> BufferPool2048 = new NcsObjectPool<CGD.buffer>(() => new CGD.buffer(2048));
        private static NcsObjectPool<CGD.buffer> BufferPool4096 = new NcsObjectPool<CGD.buffer>(() => new CGD.buffer(4096));
        private static NcsObjectPool<CGD.buffer> BufferPool8192 = new NcsObjectPool<CGD.buffer>(() => new CGD.buffer(8192));

        public static CGD.buffer BufferPool
        {
            get;

        }
    }
}
