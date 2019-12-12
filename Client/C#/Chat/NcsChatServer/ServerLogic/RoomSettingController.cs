using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CGD;
using NcsChatProtocol;
using NcsChatServer.BufferList;
using NcsChatServer.Type;
using NcsChatServer.User;
using NcsCore;

namespace NcsChatServer.ServerLogic
{
    public class RoomSettingController : NcsModule<ChatUser>
    {
        public RoomSettingController()
        {
            packet[(ushort) Protocol.RoomCreate] = (pUser, pInfo) =>
            {
                var buffer = pInfo.Body;

                buffer.extract_int();
                buffer.extract_short();

                var dataName = buffer.extract_string();
                Program.ConsoleSystem.WriteLog($"[Recv] RoomCreate - {dataName}");

                if (!Program.RoomDictionary.ContainsKey(dataName))
                {
                    Program.RoomDictionary.Add(dataName, new Room()
                    {
                        roomName = dataName
                    });

                    Program.ConsoleSystem.WriteLog($"[Send] {dataName} - ResRoomCreate0");

                    Program.ConsoleSystem.AddRoomCount(1);
                    pUser.Send(DefinitionBuffer.ResRoomCreate0); // 정상처리
                }
                else
                {
                    Program.ConsoleSystem.WriteLog($"[Send] {dataName} - ResRoomCreate1");
                    pUser.Send(DefinitionBuffer.ResRoomCreate1); // 방이름 중복
                }
            };

            packet[(ushort)Protocol.RoomList] = (pUser, pInfo) =>
            {
                Program.ConsoleSystem.WriteLog($"[Recv] RoomList");
                var roomList = Program.RoomDictionary.Keys.ToList();
                var buffer = new NcsBuffer(16384);;
                    
                buffer.append<uint>(0);
                buffer.append<ushort>(Protocol.ResRoomList);
                buffer.append(roomList);
                buffer.set_front<uint>(buffer.Count);

                Program.ConsoleSystem.WriteLog($"[Send] ResRoomList - {roomList.Count}...");

                pUser.Send(buffer); // 방이름 중복
            };
        }
    }
}
