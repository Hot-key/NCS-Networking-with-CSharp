namespace Ncs.Pool
{
    public class NcsPool
    {
        public NcsArrayPool<byte>[] poolArray;

        private static NcsPool _ncsPool = new NcsPool();

        public NcsPool()
        {
            poolArray = new NcsArrayPool<byte>[53];

            poolArray[0] = new NcsArrayPool<byte>( 128, null);
            poolArray[1] = new NcsArrayPool<byte>( 256, null);
            poolArray[2] = new NcsArrayPool<byte>( 384, null);
            poolArray[3] = new NcsArrayPool<byte>( 512, null);
            poolArray[4] = new NcsArrayPool<byte>( 640, null);
            poolArray[5] = new NcsArrayPool<byte>( 768, null);
            poolArray[6] = new NcsArrayPool<byte>( 896, null);
            poolArray[7] = new NcsArrayPool<byte>(1024, null);
            poolArray[8] = new NcsArrayPool<byte>(2048, null);
            poolArray[9] = new NcsArrayPool<byte>(3072, null);
            poolArray[10] = new NcsArrayPool<byte>(4096, null);
            poolArray[11] = new NcsArrayPool<byte>(5120, null);
            poolArray[12] = new NcsArrayPool<byte>(6144, null);
            poolArray[13] = new NcsArrayPool<byte>(7168, null);
            poolArray[14] = new NcsArrayPool<byte>(8192, null);
            poolArray[15] = new NcsArrayPool<byte>(12288, null);
            poolArray[16] = new NcsArrayPool<byte>(16384, null);
            poolArray[17] = new NcsArrayPool<byte>(20480, null);
            poolArray[18] = new NcsArrayPool<byte>(24576, null);
            poolArray[19] = new NcsArrayPool<byte>(28672, null);
            poolArray[20] = new NcsArrayPool<byte>(32768, null);
            poolArray[21] = new NcsArrayPool<byte>(36864, null);
            poolArray[22] = new NcsArrayPool<byte>(40960, null);
            poolArray[23] = new NcsArrayPool<byte>(45056, null);
            poolArray[24] = new NcsArrayPool<byte>(49152, null);
            poolArray[25] = new NcsArrayPool<byte>(53248, null);
            poolArray[26] = new NcsArrayPool<byte>(57344, null);
            poolArray[27] = new NcsArrayPool<byte>(61440, null);
            poolArray[28] = new NcsArrayPool<byte>(65536, null);
            poolArray[29] = new NcsArrayPool<byte>(81920, null);
            poolArray[30] = new NcsArrayPool<byte>(98304, null);
            poolArray[31] = new NcsArrayPool<byte>(114688, null);
            poolArray[32] = new NcsArrayPool<byte>(131072, null);
            poolArray[33] = new NcsArrayPool<byte>(147456, null);
            poolArray[34] = new NcsArrayPool<byte>(163840, null);
            poolArray[35] = new NcsArrayPool<byte>(180224, null);
            poolArray[36] = new NcsArrayPool<byte>(196608, null);
            poolArray[37] = new NcsArrayPool<byte>(212992, null);
            poolArray[38] = new NcsArrayPool<byte>(229376, null);
            poolArray[39] = new NcsArrayPool<byte>(245760, null);
            poolArray[40] = new NcsArrayPool<byte>(262144, null);
            poolArray[41] = new NcsArrayPool<byte>(327680, null);
            poolArray[42] = new NcsArrayPool<byte>(393216, null);
            poolArray[43] = new NcsArrayPool<byte>(458752, null);
            poolArray[44] = new NcsArrayPool<byte>(524288, null);
            poolArray[45] = new NcsArrayPool<byte>(589824, null);
            poolArray[46] = new NcsArrayPool<byte>(655360, null);
            poolArray[47] = new NcsArrayPool<byte>(720896, null);
            poolArray[48] = new NcsArrayPool<byte>(786432, null);
            poolArray[49] = new NcsArrayPool<byte>(851968, null);
            poolArray[50] = new NcsArrayPool<byte>(917504, null);
            poolArray[51] = new NcsArrayPool<byte>(983040, null);
            poolArray[52] = new NcsArrayPool<byte>(1048576, null);
        }
        
        public static int SelectPool(int size)
        {
            if (size <= 8192)
            {
                if (size <= 1024)
                {
                    return size - 1 >> 7;
                }
                return (size - 1 >> 10) + 7;
            }

            if (size <= 65536)
            {
                return (size - 1 >> 12) + 13;
            }
            if (size <= 262144)
            {
                return (size - 1 >> 14) + 25;
            }
            return (size - 1 >> 16) + 37;
        }
        public static byte[] TakeBuffer(int size)
        {
            return NcsPool._ncsPool.GetObject(NcsPool.SelectPool(size));
        }
        public static void ReturnBuffer(byte[] buffer)
        {
            if (buffer == null)
            {
                return;
            }
            NcsPool._ncsPool.PutObject(NcsPool.SelectPool(buffer.Length), buffer);
        }

        private byte[] GetObject(int bufferPos)
        {
            return NcsPool._ncsPool.poolArray[bufferPos].GetObject();
        }

        private void PutObject(int bufferPos, byte[] item)
        {
            NcsPool._ncsPool.poolArray[bufferPos].PutObject(item);
        }
    }
}
