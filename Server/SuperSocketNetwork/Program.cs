using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Config;
using SuperSocketNetwork.Ncs;

namespace SuperSocketNetwork
{
    class Program
    {
        public static ServerConfig mConfig = new ServerConfig()
        {
            Port = 65535,
            Ip = "Any",
            MaxConnectionNumber = 5000,
            Mode = SocketMode.Tcp,
            Name = "NcsMain",
        };

        public static NcsMain ncsServer = new NcsMain(mConfig);

        /// Signal
        public const int signal_heartbeat_first = 1;
        public const int signal_heartbeat_second = 2;
        public const int signal_login = 3;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.ReadLine();
            }
        }

    }
}
