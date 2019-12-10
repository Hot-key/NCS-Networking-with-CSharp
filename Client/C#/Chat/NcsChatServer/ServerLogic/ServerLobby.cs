using NcsCore;

namespace NcsChatServer
{
    public class ServerLobby : NcsModule<ChatUser>
    {
        public ServerLobby()
        {
            NewSessionConnected = pUser =>
            {

            };
        }
    }
}