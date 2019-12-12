using System;
using System.Collections.Generic;
using System.Text;

namespace NcsChatProtocol
{
    // 0x0000 - 사용 목적 분류
    // 0x000  - 형식 지정 - 0x000(클라이언트 요청) ,0x100(서버 응답(값 반환)), 0x200(서버 응답(값 반환x)), 0x500(브로드캐스트)
    // 0x00, 0x0 - 사용 목적 구분
    public enum Protocol : ushort
    {
        /// <summary>
        /// 길이(32) | RoomCreate(16) | 방이름(string)
        /// </summary>
        RoomCreate = 0x1001, // 방 만들기

        /// <summary>
        /// 길이(32) | RoomCreate(16) | 0(완료, 16), 1(방이름 중복, 16)
        /// </summary>
        ResRoomCreate = 0x1101, // 방 만들기 응답
        /// <summary>
        /// 길이(32) | RoomConnection(16) | 방이름(string)
        /// </summary>
        RoomConnection = 0x1012, // 방 연결
        /// <summary>
        /// 길이(32) | RoomConnection(16) | 0(완료, 16), 1(방이름 없음, 16)
        /// </summary>
        ResRoomConnection = 0x1012, // 방 연결 응답
        /// <summary>
        /// 길이(32) | RoomDisconnection(16) | 방이름(string)
        /// </summary>
        RoomDisconnection = 0x1013, // 방 접속종료
        /// <summary>
        /// 길이(32) | RoomList(16)
        /// </summary>
        RoomList = 0x1021, // 방 목록
        /// <summary>
        /// 길이(32) | RoomList(16) | 방 목록(List&lt;string&gt;)
        /// </summary>
        ResRoomList = 0x1021, // 방 목록 응답

        /// <summary>
        /// 길이(32) | RoomUserList(16)
        /// </summary>  
        RoomUserList = 0x2001, // 모든 유저 정보
        /// <summary>
        /// 길이(32) | ResRoomUserList(16) | 유저 목록(List&lt;string&gt;)
        /// </summary>
        ResRoomUserList = 0x2001, // 모든 유저 정보 응답
        RoomUserCount = 0x2002, // 방의 유저 수
        RoomUserInfo  = 0x2003, // 특정 유저의 정보

        /// <summary>
        /// 길이(32) | ReqRoomUserNameChange(16) | 아이디(string) | 변경된 이름(string)
        /// </summary>
        ResRoomUserNameChange = 0x2511, // 이름변경 브로드캐스트

        /// <summary>
        /// 길이(32) | UserLogin(16) | 아이디(string) | 비밀번호(string)
        /// </summary>
        UserLogin = 0x3001, // 로그인
        /// <summary>
        /// 길이(32) | UserRegister(16) | 0(완료, 16), 1(아이디 없음, 16), 2(비밀번호 틀림, 16)| 이름(string)
        /// </summary>
        ResUserLogin = 0x3101, // 로그인 응답
        /// <summary>
        /// 길이(32) | UserRegister(16) | 아이디(string) | 비밀번호(string)
        /// </summary>
        UserRegister = 0x3002, // 회원가입
        /// <summary>
        /// 길이(32) | UserRegister(16) | 0(완료, 16), 1(아이디 중복, 16)
        /// </summary>
        ResUserRegister = 0x3102, // 회원가입 응답

        /// <summary>
        /// 길이(32) | UserNameChange(16) | 이름(string)
        /// </summary>
        UserNameChange = 0x3011, // 이름변경

        /// <summary>
        /// 길이(32) | ResUserNameChange(16) | 0(완료, 16) | 1(로그인 필요, 16)
        /// </summary>
        ResUserNameChange = 0x3111, // 이름변경 응답

        RoomSendMessage   = 0x4001, // 메시지 전송
        RoomRemoveMessage = 0x4002, // 메시지 지우기
        RoomEditMessage   = 0x4003, // 메시지 수정
    }
}