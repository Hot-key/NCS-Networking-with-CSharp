using System;
using System.Collections.Generic;
using System.Text;
using CGD;
using NcsChatServer.User;

namespace NcsChatServer.Type
{
    public class Room
    {
        public string roomName;

        public List<ChatUser> userList = new List<ChatUser>();

        public void RoomConnection(ChatUser user)
        {
            lock (userList)
            {
                userList.Add(user);
            }
        }

        public void RoomDisconnection(ChatUser user)
        {
            lock (userList)
            {
                userList.Remove(user);
            }
        }

        public bool RoomUserExists(ChatUser user)
        {
            lock (userList)
            {
                return userList.Exists(s => s.userData.Id == user.userData.Id);
            }
        }

        public void BroadcastPacket(NcsBuffer data)
        {
            lock (userList)
            {
                for (var i = 0; i < userList.Count; i++)
                {
                    userList[i].Send(data);
                }
            }
        }
    }
}
