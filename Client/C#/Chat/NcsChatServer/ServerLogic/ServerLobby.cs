using NcsCore;

namespace NcsChatServer
{
    public class ServerLobby : NcsModule<ChatUser>
    {
        public ServerLobby()
        {
            NewSessionConnected = pUser =>
            {
                Program.ConsoleSystem.WriteLog("[Server] NewSessionConnected!");
                Program.ConsoleSystem.AddUserCount(1);
            };
        }
    }
}