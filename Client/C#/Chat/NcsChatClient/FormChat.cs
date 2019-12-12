using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CGD;
using NcsChatProtocol;
using SuperSocket.ClientEngine;

namespace NcsChatClient
{
    public partial class FormChat : Form
    {
        private EasyClient<NcsRequestInfo> client;
        private string roomName;

        public FormChat(EasyClient<NcsRequestInfo> client, string roomName)
        {
            InitializeComponent();

            this.client = client;
            this.roomName = roomName;
            this.Text = roomName;
        }

        private void FormChat_Load(object sender, EventArgs e)
        {
            client.NewPackageReceived += ClientOnNewPackageReceived;

            var buffer = new NcsBuffer(32);

            buffer.append<uint>(0);
            buffer.append<ushort>(Protocol.RoomUserList);
            buffer.set_front<uint>(buffer.Count);

            client.Send(buffer);
        }

        private void ClientOnNewPackageReceived(object sender, PackageEventArgs<NcsRequestInfo> e)
        {
            switch (e.Package.Key)
            {
                case (ushort) Protocol.ResRoomUserList:
                {
                    var buffer = e.Package.Body;

                    var roomList = buffer.extract<List<string>>();
                    this.Invoke(new Action(() =>
                    {
                        listBoxUserList.Items.Clear();
                        foreach (var roomName in roomList)
                        {
                            listBoxUserList.Items.Add(roomName);
                        }
                    }));
                        break;
                }
            }
        }
    }
}
