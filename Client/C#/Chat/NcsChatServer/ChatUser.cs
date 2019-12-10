using NcsCore.Server;

namespace NcsChatServer
{
    public class ChatUser : NcsUser<ChatUser>
    {
        public int roomNum;
        public string name;
    }
}