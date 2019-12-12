using System;
using System.Collections.Generic;
using System.Text;

namespace NcsChatClient
{
    // 0x0000 - ��� ���� �з�
    // 0x000  - ���� ���� - 0x000(Ŭ���̾�Ʈ ��û) ,0x100(���� ����(�� ��ȯ)), 0x200(���� ����(�� ��ȯx))
    // 0x00, 0x0 - ��� ���� ����
    public enum Protocol : ushort
    {
        RoomConnection    = 0x1001, // �� �����
        RoomDisconnection = 0x1002, // �� ��������

        RoomUserList  = 0x2001, // ��� ���� ����
        RoomUserCount = 0x2002, // ���� ���� ��
        RoomUserInfo  = 0x2003, // Ư�� ������ ����

        /// <summary>
        /// ����(32) | UserLogin(16) | ���̵�(string) | ��й�ȣ(string)
        /// </summary>
        UserLogin = 0x3001, // �α���
        /// <summary>
        /// ����(32) | UserRegister(16) | 0(�Ϸ�, 16), 1(���̵� ����, 16), 2(��й�ȣ Ʋ��, 16)| �̸�(string)
        /// </summary>
        ReqUserLogin = 0x3101, // �α��� ����
        /// <summary>
        /// ����(32) | UserRegister(16) | ���̵�(string) | ��й�ȣ(string)
        /// </summary>
        UserRegister = 0x3002, // ȸ������
        /// <summary>
        /// ����(32) | UserRegister(16) | 0(�Ϸ�, 16), 1(���̵� �ߺ�, 16)
        /// </summary>
        ReqUserRegister = 0x3102, // ȸ������ ����

        /// <summary>
        /// ����(32) | UserNameChange(16) | �̸�(string)
        /// </summary>
        UserNameChange = 0x3011, // �̸�����

        /// <summary>
        /// ����(32) | ReqUserNameChange(16) | ���̵�(string) | ��й�ȣ(string)
        /// </summary>
        ReqUserNameChange = 0x3211, // �̸����� �Ϸ�

        RoomSendMessage   = 0x4001, // �޽��� ����
        RoomRemoveMessage = 0x4002, // �޽��� �����
        RoomEditMessage   = 0x4003, // �޽��� ����
    }
}