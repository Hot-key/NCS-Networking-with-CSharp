using System;
using System.Collections.Generic;
using System.Text;
using NcsChatServer.User;
using NcsCore;

namespace NcsChatServer.ServerLogic
{
    public class UserCount : NcsModule<ChatUser>
    {
        public UserCount()
        {
            NewSessionConnected = pUser =>
            {
                Program.ConsoleSystem.WriteLog("[Server] NewSessionConnected!");
                Program.ConsoleSystem.AddUserCount(1);
                pUser.roomName = "";
            };

            SessionClosed = (pUser, pReason) =>
            {
                Program.ConsoleSystem.WriteLog("[Server] SessionClosed!");
                Program.ConsoleSystem.AddUserCount(-1);
            };
        }
    }
}
