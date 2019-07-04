using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGD;
using Ncs.Routing;
using Ncs.Server;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;

namespace Ncs.ConsoleTest
{
    class Program
    {
        private static NcsMain<NewUser> server;
        static void Main(string[] args)
        {
            NcsTemplateBuffer.SetTempBuffer();
            server = new NcsMain<NewUser>(new ServerConfig()
            {
                Port = 65535,
                Ip = "Any",

                MaxConnectionNumber = 1000,
                SendBufferSize = 32768,
                ReceiveBufferSize = 4096,
                MaxRequestLength = 1048576,
                SyncSend = true,
                SendingQueueSize = 64,

                Mode = SocketMode.Tcp,
                Name = "NcsMain",
            });

            while (Console.ReadLine() != "q")
            {
                
            }
        }
    }

    public class NewUser : NcsUser<NewUser>
    {
        public bool heartbeat = false;
    }

    public class Test : NcsModule<NewUser>
    {
        public Test()
        {
            packet[(ushort)1] = async (user, info) =>
            {
                user.Send(info.Body);
                //user.heartbeat = true;
                //await user.SendAsync(NcsTemplateBuffer.HeartbeatBuffer2);
            };

            packet[(ushort)2] = (user, info) =>
            {
                user.Send(info.Body);
            };

            NewSessionConnected = user =>
            {
                //Console.WriteLine("NewSessionConnected");
                //new Task(async () =>
                //{
                //    int heartbeat_count = 0;
                //    while (true)
                //    {
                //        if (heartbeat_count >= 10)
                //        {
                //            user.heartbeat = false;
                //        }
                //        else
                //        {
                //            heartbeat_count++;
                //        }
                //        user.Send(NcsTemplateBuffer.HeartbeatBuffer1);
                //        await Task.Delay(1000);
                //        if ((user.heartbeat == false) && (heartbeat_count >= 10))
                //        {
                //            user.Close();
                //        }
                //        else
                //        {
                //            continue;
                //        }
                //        if (heartbeat_count >= 10)
                //        {
                //            heartbeat_count = 0;
                //        }
                //    }

                //}).Start();
            };
        }
    }
}
