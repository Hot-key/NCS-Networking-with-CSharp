using System;
using System.Collections.Generic;
using System.Text;
using CGD;
using NcsChatProtocol;
using NcsChatServer.BufferList;
using NcsChatServer.Data;
using NcsChatServer.User;
using NcsCore;
using NcsCore.Server;

namespace NcsChatServer.ServerLogic
{
    public class UserInfoController : NcsModule<ChatUser>
    {
        public UserInfoController()
        {
            packet[(ushort)Protocol.UserNameChange] = (pUser, pInfo) =>
            {
                if (pUser.isLogin) // 로그인 먼저 확인
                {
                    var buffer = pInfo.Body;

                    buffer.extract_int();
                    buffer.extract_short();

                    var dataName = buffer.extract_string();

                    if (pUser.roomName != "")
                    {
                        var broadcastData = new NcsBuffer(1024);

                        broadcastData.append<uint>(0);
                        broadcastData.append<ushort>(Protocol.ResRoomUserNameChange);
                        broadcastData.append<string>(pUser.userData.Id);
                        broadcastData.append<string>(dataName);

                        Program.RoomDictionary[pUser.roomName].BroadcastPacket(broadcastData); // 이름변경 알림
                    }

                    pUser.userData.Name = dataName;
                    DataBase.UserCollection.Update(pUser.userData);

                    pUser.Send(DefinitionBuffer.ResUserNameChange0); // 정상처리
                }
                else
                {
                    pUser.Send(DefinitionBuffer.ResUserNameChange1); // 로그인 안함
                }
            };
        }
    }
}
