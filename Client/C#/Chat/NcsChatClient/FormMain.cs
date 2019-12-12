using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CGD;
using NcsChatProtocol;
using SuperSocket.ClientEngine;

namespace NcsChatClient
{
    public partial class FormMain : Form
    {
        private static EasyClient<NcsRequestInfo> client;

        private string name;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            client = new EasyClient<NcsRequestInfo>();
            client.Initialize(new NcsReceiveFilter());
            client.Connected += OnClientConnected;
            client.NewPackageReceived += Client_NewPackageReceived;
            client.Error += OnClientError;
            client.Closed += OnClientClosed;
        }

        private void OnClientConnected(object sender, EventArgs e)
        {

        }

        private void OnClientClosed(object sender, EventArgs e)
        {
            MessageBox.Show("서버와 연결이 끊어졌습니다!");
            this.Invoke(new Action(() =>
            {
                this.buttonConnectServer.Enabled = true;
                this.textBoxIpAddress.Enabled    = true;
                this.textBoxPort.Enabled         = true;
                this.buttonLogin.Enabled         = true;
                this.buttonRegister.Enabled      = true;
            }));
        }

        private void OnClientError(object sender, ErrorEventArgs e)
        {

        }

        private void Client_NewPackageReceived(object sender, PackageEventArgs<NcsRequestInfo> e)
        {
            switch (e.Package.Key)
            {
                case (ushort) Protocol.ResUserRegister:
                {
                    var buffer = e.Package.Body;

                    var code = buffer.extract_short();
                    if (code == 0)
                    {
                        MessageBox.Show("회원가입 성공");
                    }
                    else if (code == 1)
                    {
                        MessageBox.Show("동일한 아이디가 있습니다");
                    }

                    break;
                }
                case (ushort) Protocol.ResUserLogin:
                {
                    var buffer = e.Package.Body;

                    var code = buffer.extract_short();
                    if (code == 0)
                    {
                        var name = buffer.extract_string();

                        this.Invoke(new Action(() =>
                        {
                            textBoxName.Text = name;
                            buttonLogin.Enabled = false;
                            buttonRegister.Enabled = false;

                            buttonReLoadRoomList.PerformClick();
                        }));
                        this.name = name;
                        MessageBox.Show($"{name}님 환영합니다.");
                    }
                    else if (code == 1)
                    {
                        MessageBox.Show("일치하는 아이디가 없습니다.");
                    }
                    else if (code == 2)
                    {
                        MessageBox.Show("비밀번호가 다릅니다.");
                    }

                    break;
                }
                case (ushort) Protocol.ResUserNameChange:
                {
                    var buffer = e.Package.Body;

                    var code = buffer.extract_short();
                    if (code == 0)
                    {
                        MessageBox.Show($"이름을 {this.name}에서 {textBoxName.Text}으로 변경하였습니다.");
                    }
                    else if (code == 1)
                    {
                        this.Invoke(new Action(() => { textBoxName.Text = this.name; }));
                        MessageBox.Show("로그인을 하지 않았거나 로그인 데이터가 만료되었습니다.");
                    }

                    break;
                }
                case (ushort) Protocol.ResRoomCreate:
                {
                    var buffer = e.Package.Body;

                    var code = buffer.extract_short();
                    if (code == 0)
                    {
                        this.Invoke(new Action(() => { buttonReLoadRoomList.PerformClick(); }));
                        MessageBox.Show("생성이 완료되었습니다.");
                    }
                    else if (code == 1)
                    {
                        MessageBox.Show("이미 있는 방 이름 입니다.");
                    }

                    break;
                }
                case (ushort) Protocol.ResRoomList:
                {
                    var buffer = e.Package.Body;

                    var roomList = buffer.extract<List<string>>();
                    this.Invoke(new Action(() =>
                    {
                        listBoxRoomList.Items.Clear();
                        foreach (var roomName in roomList)
                        {
                            listBoxRoomList.Items.Add(roomName);
                        }
                    }));
                    break;
                }
            }
        }

        private void buttonConnectServer_Click(object sender, EventArgs e)
        {
            new Task(async () =>
            {
                this.Invoke(new Action(() =>
                {
                    this.buttonConnectServer.Enabled = false;
                    this.textBoxIpAddress.Enabled = false;
                    this.textBoxPort.Enabled = false;
                }));

                await client.ConnectAsync(new IPEndPoint(IPAddress.Parse(textBoxIpAddress.Text),
                    Convert.ToInt32(textBoxPort.Text)));

                this.Invoke(new Action(() =>
                {
                    if (!client.IsConnected)
                    {
                        this.buttonConnectServer.Enabled = true;
                        this.textBoxIpAddress.Enabled = true;
                        this.textBoxPort.Enabled = true;
                    }
                }));
            }).Start();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var buffer = new NcsBuffer(1024);

            buffer.append<uint>(0);
            buffer.append<ushort>(Protocol.UserLogin);
            buffer.append<string>(textBoxId.Text);
            buffer.append<string>(textBoxPw.Text);
            buffer.set_front<uint>(buffer.Count);

            client.Send(buffer);
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            var buffer = new NcsBuffer(1024);

            buffer.append<uint>(0);
            buffer.append<ushort>(Protocol.UserRegister);
            buffer.append<string>(textBoxId.Text);
            buffer.append<string>(textBoxPw.Text);
            buffer.set_front<uint>(buffer.Count);

            client.Send(buffer);
        }

        private void timerRefreshRoom_Tick(object sender, EventArgs e)
        {
            buttonReLoadRoomList.PerformClick();
        }

        private void buttonNameChange_Click(object sender, EventArgs e)
        {
            var buffer = new NcsBuffer(1024);

            buffer.append<uint>(0);
            buffer.append<ushort>(Protocol.UserNameChange);
            buffer.append<string>(textBoxName.Text);
            buffer.set_front<uint>(buffer.Count);

            client.Send(buffer);
        }

        private void buttonCreateRoom_Click(object sender, EventArgs e)
        {
            var buffer = new NcsBuffer(1024);

            buffer.append<uint>(0);
            buffer.append<ushort>(Protocol.RoomCreate);
            buffer.append<string>(textBoxRoomName.Text);
            buffer.set_front<uint>(buffer.Count);

            client.Send(buffer);
        }

        private void buttonReLoadRoomList_Click(object sender, EventArgs e)
        {
            var buffer = new NcsBuffer(32);

            buffer.append<uint>(0);
            buffer.append<ushort>(Protocol.RoomList);
            buffer.set_front<uint>(buffer.Count);

            client.Send(buffer);
        }

        private void buttonRoomJoin_Click(object sender, EventArgs e)
        {
            if (listBoxRoomList.SelectedIndex != -1)
            {
                new FormChat(client, listBoxRoomList.Items[listBoxRoomList.SelectedIndex].ToString()).Show();
            }
        }
    }
}
