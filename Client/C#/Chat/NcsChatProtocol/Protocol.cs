using System;
using System.Collections.Generic;
using System.Text;

namespace NcsChatProtocol
{
    // 0x0000 - ��� ���� �з�
    // 0x000  - ���� ���� - 0x000(Ŭ���̾�Ʈ ��û) ,0x100(���� ����(�� ��ȯ)), 0x200(���� ����(�� ��ȯx)), 0x500(��ε�ĳ��Ʈ)
    // 0x00, 0x0 - ��� ���� ����
    public enum Protocol : ushort
    {
        /// <summary>
        /// ����(32) | RoomCreate(16) | ���̸�(string)
        /// </summary>
        RoomCreate = 0x1001, // �� �����

        /// <summary>
        /// ����(32) | RoomCreate(16) | 0(�Ϸ�, 16), 1(���̸� �ߺ�, 16)
        /// </summary>
        ResRoomCreate = 0x1101, // �� ����� ����
        /// <summary>
        /// ����(32) | RoomConnection(16) | ���̸�(string)
        /// </summary>
        RoomConnection = 0x1012, // �� ����
        /// <summary>
        /// ����(32) | RoomConnection(16) | 0(�Ϸ�, 16), 1(���̸� ����, 16)
        /// </summary>
        ResRoomConnection = 0x1012, // �� ���� ����
        /// <summary>
        /// ����(32) | RoomDisconnection(16) | ���̸�(string)
        /// </summary>
        RoomDisconnection = 0x1013, // �� ��������
        /// <summary>
        /// ����(32) | RoomList(16)
        /// </summary>
        RoomList = 0x1021, // �� ���
        /// <summary>
        /// ����(32) | RoomList(16) | �� ���(List&lt;string&gt;)
        /// </summary>
        ResRoomList = 0x1021, // �� ��� ����

        /// <summary>
        /// ����(32) | RoomUserList(16)
        /// </summary>  
        RoomUserList = 0x2001, // ��� ���� ����
        /// <summary>
        /// ����(32) | ResRoomUserList(16) | ���� ���(List&lt;string&gt;)
        /// </summary>
        ResRoomUserList = 0x2001, // ��� ���� ���� ����
        RoomUserCount = 0x2002, // ���� ���� ��
        RoomUserInfo  = 0x2003, // Ư�� ������ ����

        /// <summary>
        /// ����(32) | ReqRoomUserNameChange(16) | ���̵�(string) | ����� �̸�(string)
        /// </summary>
        ResRoomUserNameChange = 0x2511, // �̸����� ��ε�ĳ��Ʈ

        /// <summary>
        /// ����(32) | UserLogin(16) | ���̵�(string) | ��й�ȣ(string)
        /// </summary>
        UserLogin = 0x3001, // �α���
        /// <summary>
        /// ����(32) | UserRegister(16) | 0(�Ϸ�, 16), 1(���̵� ����, 16), 2(��й�ȣ Ʋ��, 16)| �̸�(string)
        /// </summary>
        ResUserLogin = 0x3101, // �α��� ����
        /// <summary>
        /// ����(32) | UserRegister(16) | ���̵�(string) | ��й�ȣ(string)
        /// </summary>
        UserRegister = 0x3002, // ȸ������
        /// <summary>
        /// ����(32) | UserRegister(16) | 0(�Ϸ�, 16), 1(���̵� �ߺ�, 16)
        /// </summary>
        ResUserRegister = 0x3102, // ȸ������ ����

        /// <summary>
        /// ����(32) | UserNameChange(16) | �̸�(string)
        /// </summary>
        UserNameChange = 0x3011, // �̸�����

        /// <summary>
        /// ����(32) | ResUserNameChange(16) | 0(�Ϸ�, 16) | 1(�α��� �ʿ�, 16)
        /// </summary>
        ResUserNameChange = 0x3111, // �̸����� ����

        RoomSendMessage   = 0x4001, // �޽��� ����
        RoomRemoveMessage = 0x4002, // �޽��� �����
        RoomEditMessage   = 0x4003, // �޽��� ����
    }
}