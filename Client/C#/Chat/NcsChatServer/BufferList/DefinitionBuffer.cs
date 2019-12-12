using System;
using System.Collections.Generic;
using System.Text;
using CGD;
using NcsChatProtocol;

namespace NcsChatServer.BufferList
{
    public static class DefinitionBuffer
    {
        /// <summary>
        /// 회원가입 정상처리
        /// </summary>
        public static NcsBuffer ResUserRegister0;

        /// <summary>
        /// 회원가입 아이디 중복
        /// </summary>
        public static NcsBuffer ResUserRegister1;

        /// <summary>
        /// 로그인 정상처리
        /// </summary>
        public static NcsBuffer ResUserLogin0;

        /// <summary>
        /// 로그인 아이디없음
        /// </summary>
        public static NcsBuffer ResUserLogin1;

        /// <summary>
        /// 로그인 비밀번호 틀림
        /// </summary>
        public static NcsBuffer ResUserLogin2;

        /// <summary>
        /// 이름변경 정상처리
        /// </summary>
        public static NcsBuffer ResUserNameChange0;

        /// <summary>
        /// 이름변경 로그인 안함
        /// </summary>
        public static NcsBuffer ResUserNameChange1;

        /// <summary>
        /// 방만들기 정상처리
        /// </summary>
        public static NcsBuffer ResRoomCreate0;

        /// <summary>
        /// 방만들기 방이름 중복
        /// </summary>
        public static NcsBuffer ResRoomCreate1;

        /// <summary>
        /// 방접속 정상처리
        /// </summary>
        public static NcsBuffer ResRoomConnection0;

        /// <summary>
        /// 방접속 방 없음
        /// </summary>
        public static NcsBuffer ResRoomConnection1;

        public static void InitData()
        {
            #region ResUserRegister0
            ResUserRegister0 = new NcsBuffer(32);
            ResUserRegister0.append<uint>(0);
            ResUserRegister0.append<ushort>(Protocol.ResUserRegister);
            ResUserRegister0.append<ushort>(0);
            ResUserRegister0.set_front<uint>(ResUserRegister0.Count);

            ResUserRegister1 = new NcsBuffer(32);
            ResUserRegister1.append<uint>(0);
            ResUserRegister1.append<ushort>(Protocol.ResUserRegister);
            ResUserRegister1.append<ushort>(1);
            ResUserRegister1.set_front<uint>(ResUserRegister1.Count);
            #endregion

            #region ResUserLogin0
            ResUserLogin0 = new NcsBuffer(32);
            ResUserLogin0.append<uint>(0);
            ResUserLogin0.append<ushort>(Protocol.ResUserLogin);
            ResUserLogin0.append<ushort>(0);
            ResUserLogin0.set_front<uint>(ResUserLogin0.Count);

            ResUserLogin1 = new NcsBuffer(32);
            ResUserLogin1.append<uint>(0);
            ResUserLogin1.append<ushort>(Protocol.ResUserLogin);
            ResUserLogin1.append<ushort>(1);
            ResUserLogin1.set_front<uint>(ResUserLogin1.Count);

            ResUserLogin2 = new NcsBuffer(32);
            ResUserLogin2.append<uint>(0);
            ResUserLogin2.append<ushort>(Protocol.ResUserLogin);
            ResUserLogin2.append<ushort>(2);
            ResUserLogin2.set_front<uint>(ResUserLogin2.Count);
            #endregion

            #region ResUserNameChange0
            ResUserNameChange0 = new NcsBuffer(32);
            ResUserNameChange0.append<uint>(0);
            ResUserNameChange0.append<ushort>(Protocol.ResUserNameChange);
            ResUserNameChange0.append<ushort>(0);
            ResUserNameChange0.set_front<uint>(ResUserLogin2.Count);

            ResUserNameChange1 = new NcsBuffer(32);
            ResUserNameChange1.append<uint>(0);
            ResUserNameChange1.append<ushort>(Protocol.ResUserNameChange);
            ResUserNameChange1.append<ushort>(1);
            ResUserNameChange1.set_front<uint>(ResUserLogin2.Count);
            #endregion

            #region ResRoomCreate0
            ResRoomCreate0 = new NcsBuffer(32);
            ResRoomCreate0.append<uint>(0);
            ResRoomCreate0.append<ushort>(Protocol.ResRoomCreate);
            ResRoomCreate0.append<ushort>(0);
            ResRoomCreate0.set_front<uint>(ResUserLogin2.Count);

            ResRoomCreate1 = new NcsBuffer(32);
            ResRoomCreate1.append<uint>(0);
            ResRoomCreate1.append<ushort>(Protocol.ResRoomCreate);
            ResRoomCreate1.append<ushort>(1);
            ResRoomCreate1.set_front<uint>(ResUserLogin2.Count);
            #endregion

            #region ResRoomConnection0
            ResRoomConnection0 = new NcsBuffer(32);
            ResRoomConnection0.append<uint>(0);
            ResRoomConnection0.append<ushort>(Protocol.ResRoomConnection);
            ResRoomConnection0.append<ushort>(0);
            ResRoomConnection0.set_front<uint>(ResRoomConnection0.Count);

            ResRoomConnection1 = new NcsBuffer(32);
            ResRoomConnection1.append<uint>(0);
            ResRoomConnection1.append<ushort>(Protocol.ResRoomConnection);
            ResRoomConnection1.append<ushort>(1);
            ResRoomConnection1.set_front<uint>(ResRoomConnection1.Count);
            #endregion

            #region ResUserRegister0
            #endregion

            #region ResUserRegister0
            #endregion
        }
    }
}
