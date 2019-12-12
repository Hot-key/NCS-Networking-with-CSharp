using NcsChatProtocol;
using NcsChatServer.Data;
using NcsChatServer.User;
using NcsCore;

namespace NcsChatServer.ServerLogic
{
    public class AuthController : NcsModule<ChatUser>
    {
        public AuthController()
        {
            packet[(ushort) Protocol.UserRegister] = (pUser, pInfo) =>
            {
                var buffer = pInfo.Body;

                buffer.extract_int();
                buffer.extract_short();

                var dataId = buffer.extract_string();
                var dataPassword = buffer.extract_string();

                Program.ConsoleSystem.WriteLog($"[Recv] UserRegister - {dataId}");

                if (DataBase.UserCollection.Exists(s => s.Id == dataId))
                {
                    Program.ConsoleSystem.WriteLog($"[Send] {dataId} - ReqUserRegister1");
                    pUser.Send(BufferList.DefinitionBuffer.ResUserRegister1); // 아이디 중복
                }
                else
                {
                    var userData = new Data.UserData()
                    {
                        Id = dataId,
                        Password = Function.Auth.StringToHash(dataPassword),
                        Name = dataId,
                    };
                    DataBase.UserCollection.Insert(userData);

                    Program.ConsoleSystem.WriteLog($"[Send] {dataId} - ReqUserRegister0");
                    pUser.Send(BufferList.DefinitionBuffer.ResUserRegister0); // 정상처리
                }
            };

            packet[(ushort) Protocol.UserLogin] = (pUser, pInfo) =>
            {
                var buffer = pInfo.Body;

                buffer.extract_int();
                buffer.extract_short();

                var dataId = buffer.extract_string();
                var dataPassword = buffer.extract_string();

                Program.ConsoleSystem.WriteLog($"[Recv] UserLogin - {dataId}");

                if (DataBase.UserCollection.Exists(s => s.Id == dataId))
                {
                    var userData = DataBase.UserCollection.FindById(dataId);

                    if (Function.Auth.StringToHash(dataPassword) == userData.Password)
                    {
                        var tmpBuffer = BufferList.DefinitionBuffer.ResUserLogin0.clone();

                        tmpBuffer.append<string>(userData.Name);
                        tmpBuffer.set_front<uint>(tmpBuffer.Count);

                        Program.ConsoleSystem.WriteLog($"[Send] {dataId} - ReqUserLogin0");


                        pUser.isLogin = true;
                        pUser.userData = userData;

                        pUser.Send(tmpBuffer); // 정상처리
                    }
                    else
                    {
                        Program.ConsoleSystem.WriteLog($"[Send] {dataId} - ReqUserLogin2");
                        pUser.Send(BufferList.DefinitionBuffer.ResUserLogin2); // 비밀번호 틀림
                    }
                }
                else
                {
                    var userData = new UserData()
                    {
                        Id = dataId,
                        Password = dataPassword,
                        Name = dataId,
                    };
                    DataBase.UserCollection.Insert(userData);

                    Program.ConsoleSystem.WriteLog($"[Send] {dataId} - ReqUserLogin1");
                    pUser.Send(BufferList.DefinitionBuffer.ResUserLogin1); // 아이디 없음
                }
            };
        }
    }
}