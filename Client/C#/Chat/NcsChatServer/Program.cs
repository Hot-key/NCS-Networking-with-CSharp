using System;
using System.Threading.Tasks;
using NcsChatServer.ConsoleHelper;
using NcsCore.Server;
using SuperSocket.SocketBase.Config;

namespace NcsChatServer
{
    class Program
    {
        public static Draw ConsoleSystem;
        static void Main(string[] args)
        {
            ConsoleSystem = new ConsoleHelper.Draw(71, 20, "NcsChatServer");

            ConsoleSystem.InitConsole();
            ConsoleSystem.SetRoomCount(0);
            ConsoleSystem.SetUserCount(0);
            ConsoleSystem.SetPortNum(65535);

            var server = new NcsMain<ChatUser>(new ServerConfig()
            {
                Port = 65535,
                Ip = "Any",
                MaxConnectionNumber = 1000,
                MaxRequestLength = 128,
            });

            new Task((async () =>
            {
                while (ConsoleSystem.IsDraw)
                {
                    ConsoleSystem.OnDraw();
                    await Task.Delay(200);
                }
            })).Start();

            while (ConsoleSystem.IsDraw)
            {
                ConsoleSystem.SendCmd(Console.ReadLine());
            }
        }
    }
}
