using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperSocket.ClientEngine;

namespace SuperSocketNetwork_WindowsForms.Ncs
{
    public class NcsMain
    {
        private AsyncTcpSession tcpSession;
        private Stopwatch pingStopwatch = new Stopwatch();

        public NcsMain(string ip, string port, Form1 form)
        {
            NcsTemplateBuffer.SetTempBuffer();

            tcpSession = new AsyncTcpSession(new IPEndPoint(IPAddress.Parse(ip), Convert.ToInt32(port)));

            tcpSession.Connected += form.tcpSession_Connected;
            tcpSession.Closed += form.tcpSession_Closed;
            tcpSession.DataReceived += form.tcpSession_DataReceived;
            tcpSession.Error += new EventHandler<ErrorEventArgs>(form.tcpSession_Error);
            tcpSession.Connect();
        }
    }
}