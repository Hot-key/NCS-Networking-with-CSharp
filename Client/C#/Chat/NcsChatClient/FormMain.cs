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
using SuperSocket.ClientEngine;

namespace NcsChatClient
{
    public partial class FormMain : Form
    {
        private static EasyClient<NcsRequestInfo> client;
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

        }

        private void OnClientError(object sender, ErrorEventArgs e)
        {

        }

        private void Client_NewPackageReceived(object sender, PackageEventArgs<NcsRequestInfo> e)
        {

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

                await client.ConnectAsync(new IPEndPoint(IPAddress.Parse(textBoxIpAddress.Text), Convert.ToInt32(textBoxPort.Text)));

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
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            var buffer = new NcsBuffer(64);

            buffer.append<uint>(0);
            buffer.append<ushort>(Protocol.UserRegister);
            buffer.append<string>(textBoxId.Text);
            buffer.append<string>(textBoxPw.Text);
            buffer.set_front<uint>(buffer.Count);

            client.Send()
        }

        private void timerRefreshRoom_Tick(object sender, EventArgs e)
        {

        }
    }

    public static class NcsClientExtension
    {
        public static void Send(this EasyClient<NcsRequestInfo> client, NcsBuffer buffer)
        {
            client.Send(buffer.buf);
        }
    }
}
