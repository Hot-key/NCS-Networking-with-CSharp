using NcsChatServer.Data;
using NcsCore.Server;

namespace NcsChatServer.User
{
    public class ChatUser : NcsUser<ChatUser>
    {
        public bool isLogin; 
        public string roomName;
        public UserData userData;
    }
}