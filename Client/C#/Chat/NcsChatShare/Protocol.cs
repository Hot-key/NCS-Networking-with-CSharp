using System;
using System.Collections.Generic;
using System.Text;

namespace NcsChatClient
{
    // 0x0000 - 사용 목적 분류
    // 0x000  - 형식 지정 - 0x000(클라이언트 요청) ,0x100(서버 응답(값 반환)), 0x200(서버 응답(값 반환x))
    // 0x00, 0x0 - 사용 목적 구분
    public enum Protocol : ushort
    {
        RoomConnection    = 0x1001, // 방 연결시
        RoomDisconnection = 0x1002, // 방 접속종료

        RoomUserList  = 0x2001, // 모든 유저 정보
        RoomUserCount = 0x2002, // 방의 유저 수
        RoomUserInfo  = 0x2003, // 특정 유저의 정보

        /// <summary>
        /// 길이(32) | UserLogin(16) | 아이디(string) | 비밀번호(string)
        /// </summary>
        UserLogin = 0x3001, // 로그인
        /// <summary>
        /// 길이(32) | UserRegister(16) | 0(완료, 16), 1(아이디 없음, 16), 2(비밀번호 틀림, 16)| 이름(string)
        /// </summary>
        ReqUserLogin = 0x3101, // 로그인 응답
        /// <summary>
        /// 길이(32) | UserRegister(16) | 아이디(string) | 비밀번호(string)
        /// </summary>
        UserRegister = 0x3002, // 회원가입
        /// <summary>
        /// 길이(32) | UserRegister(16) | 0(완료, 16), 1(아이디 중복, 16)
        /// </summary>
        ReqUserRegister = 0x3102, // 회원가입 응답

        /// <summary>
        /// 길이(32) | UserNameChange(16) | 이름(string)
        /// </summary>
        UserNameChange = 0x3011, // 이름변경

        /// <summary>
        /// 길이(32) | ReqUserNameChange(16) | 아이디(string) | 비밀번호(string)
        /// </summary>
        ReqUserNameChange = 0x3211, // 이름변경 완료

        RoomSendMessage   = 0x4001, // 메시지 전송
        RoomRemoveMessage = 0x4002, // 메시지 지우기
        RoomEditMessage   = 0x4003, // 메시지 수정
    }
}