using System;
using System.Threading.Tasks;
using CGD;
using Ncs.ConsoleTest;
using NcsCore.Server;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;

namespace NcsCore.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            NcsTemplateBuffer.SetTempBuffer();
            //var option = new NcsOption
            //(
            //    buffer => buffer.get_front_short(4),
            //    (header, offset, length) =>
            //    {
            //        return (int) header[offset] +
            //               (int) header[offset + 1] * 256;
            //    },
            //    3
            //);

            var server = new NcsMain<NewUser>(new ServerConfig()
            {
                Port = 65535,
                Ip = "Any",
                MaxConnectionNumber = 1000,
                MaxRequestLength = 128,
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
            NewRequestReceived = (user, info) =>
            {
                user.Send(info.Body);
            };

            //packet[(ushort)1] = (user, info) =>
            //{
            //    //user.Send(info.Body);
            //    //user.heartbeat = true;
            //    user.Send(NcsTemplateBuffer.HeartbeatBuffer2);
            //};

            //packet[(ushort)2] = (user, info) =>
            //{
            //    user.Send(info.Body);
            //};

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
