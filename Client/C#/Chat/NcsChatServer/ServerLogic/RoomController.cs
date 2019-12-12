using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CGD;
using NcsChatProtocol;
using NcsChatServer.BufferList;
using NcsChatServer.User;
using NcsCore;

namespace NcsChatServer.ServerLogic
{
    public class RoomController : NcsModule<ChatUser>
    {
        public RoomController()
        {
            packet[(ushort)Protocol.RoomConnection] = (pUser, pInfo) =>
            {
                var buffer = pInfo.Body;

                buffer.extract_int();
                buffer.extract_short();

                var roomName = buffer.extract_string();

                if (Program.RoomDictionary.ContainsKey(roomName))
                {
                    var room = Program.RoomDictionary[roomName];
                    room.RoomConnection(pUser);

                    pUser.roomName = roomName;
                    pUser.Send(DefinitionBuffer.ResRoomConnection0); // 정상처리
                }
                pUser.Send(DefinitionBuffer.ResRoomConnection1); // 방을 찾을 수 없음
            };

            packet[(ushort)Protocol.RoomUserList] = (pUser, pInfo) =>
            {
                Program.ConsoleSystem.WriteLog($"[Recv] RoomUserList");

                var room = Program.RoomDictionary[pUser.roomName];
                var roomUserList = room.userList.Select(s=>s.userData.Name).ToList();
                var buffer = new NcsBuffer(16384); ;

                buffer.append<uint>(0);
                buffer.append<ushort>(Protocol.ResRoomList);
                buffer.append(roomUserList);
                buffer.set_front<uint>(buffer.Count);

                Program.ConsoleSystem.WriteLog($"[Send] ResRoomList - {roomUserList.Count}...");    

                pUser.Send(buffer); // 방이름 중복
            };
        }
    }
}
