using System;
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
            ConsoleSystem = new ConsoleHelper.Draw(60, 16);

            ConsoleSystem.InitConsole();
            ConsoleSystem.SetRoomCount(0);
            ConsoleSystem.SetUserCount(0);

            var server = new NcsMain<ChatUser>(new ServerConfig()
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
}
