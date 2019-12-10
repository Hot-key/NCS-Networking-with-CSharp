using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperSocket.ClientEngine;
using SuperSocketNetwork_WindowsForms.Ncs;

namespace SuperSocketNetwork_WindowsForms
{
    public partial class Form1 : Form
    {
        private NcsMain serverMain;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (textBoxIP.Text.Length > 1 && textBoxPort.Text.Length > 1)
            {
                serverMain = new NcsMain(textBoxIP.Text, textBoxPort.Text, this);
            }
            else
            {
                MessageBox.Show("IP 와 Port 를 확인하여 주십시오");
            }
        }

        public void tcpSession_Connected(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                listBoxServerLog.Items.Add("tcpSession_Connected");
                listBoxServerLog.TopIndex = listBoxServerLog.Items.Count - 1;
            }));
        }

        public void tcpSession_Closed(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                listBoxServerLog.Items.Add("tcpSession_Closed");
                listBoxServerLog.TopIndex = listBoxServerLog.Items.Count - 1;
            }));
        }

        public void tcpSession_DataReceived(object sender, DataEventArgs e)
        {


            AsyncTcpSession session = sender as AsyncTcpSession;

            byte[] tmpBuffer = e.Data;
            var buffer = new CGD.buffer(e.Data, 0, e.Length);

            int bufferLength = (int)buffer.extract_uint();
            ushort bufferType = (ushort)buffer.extract_byte();

            switch (bufferType)
            {
                case 1:
                    session.Send(NcsTemplateBuffer.HeartbeatBuffer1);
                    break;
            }


            Invoke(new Action(() =>
            {
                listBoxServerLog.Items.Add("tcpSession_DataReceived");
                listBoxServerLog.Items.Add("---------------------------------");
                listBoxServerLog.Items.Add("Type   : " + bufferType);
                listBoxServerLog.Items.Add("Length : " + bufferLength);
                listBoxServerLog.Items.Add("Data   : " + ByteArrayToString(e.Data, e.Length));
                listBoxServerLog.Items.Add("---------------------------------");
                listBoxServerLog.TopIndex = listBoxServerLog.Items.Count - 1;
            }));
        }

        public void tcpSession_Error(object sender, ErrorEventArgs e)
        {
            Invoke(new Action(() =>
            {
                listBoxServerLog.Items.Add("tcpSession_Error");
                listBoxServerLog.Items.Add("---------------------------------");
                listBoxServerLog.Items.Add("Error : " + e.Exception.Message);
                listBoxServerLog.Items.Add("---------------------------------");
            }));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public string ByteArrayToString(byte[] ba, int length)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            for (int i = 0; i < length; i++)
            {
                hex.AppendFormat("{0:x2} ", ba[i]);
            }
            return hex.ToString();
        }
    }
}
