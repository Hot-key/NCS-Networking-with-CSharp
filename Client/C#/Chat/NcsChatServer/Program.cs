using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NcsChatServer.BufferList;
using NcsChatServer.ConsoleHelper;
using NcsChatServer.Data;
using NcsChatServer.Type;
using NcsChatServer.User;
using NcsCore.Server;
using NLog;
using SuperSocket.SocketBase.Config;

namespace NcsChatServer
{
    class Program
    {
        public static readonly Draw ConsoleSystem = new ConsoleHelper.Draw(71, 20, "NcsChatServer");
        public static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public static readonly Dictionary<string, Room> RoomDictionary = new Dictionary<string, Room>();
        static void Main(string[] args)
        {
            #region NLog
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget("logfile")
            {
                FileName = "./Data/${date:format=yyyyMMdd} - Log.txt",
                Layout = "[${longdate}][${level}] ${message}  ${exception}"
            };

            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            NLog.LogManager.Configuration = config;
            #endregion

            #region InitSystem
            ConsoleSystem.InitConsole();
            ConsoleSystem.SetRoomCount(0);
            ConsoleSystem.SetUserCount(0);
            ConsoleSystem.SetPortNum(65535);

            DataBase.InitDataBase();
            #endregion

            #region InitBuffer
            DefinitionBuffer.InitData();
            #endregion

            var server = new NcsMain<ChatUser>(new ServerConfig()
            {
                Port = 65535,
                Ip = "Any",
                MaxConnectionNumber = 1000,
            });

            #region ConsoleSystem
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
            #endregion
            // 종료처리
            NLog.LogManager.Shutdown();
        }
    }
}
