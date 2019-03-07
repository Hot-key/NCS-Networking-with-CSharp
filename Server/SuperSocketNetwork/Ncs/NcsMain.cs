using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.Common;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;

namespace SuperSocketNetwork.Ncs
{
    public partial class NcsMain
    {
        NcsServer ncsServer = new NcsServer();

        static List<NcsUser> user_list = new List<NcsUser>();

        public NcsMain(ServerConfig config)
        {
            ncsServer.Setup(new RootConfig(), config);
            ncsServer.Start();

            ncsServer.NewSessionConnected += new SessionHandler<NcsUser>(NcsServer_NewUserConnected);
            ncsServer.SessionClosed += new SessionHandler<NcsUser, CloseReason>(NcsServer_UserClosed);
            ncsServer.NewRequestReceived += new RequestHandler<NcsUser, NcsRequestInfo>(NcsServer_NewRequestReceived);
        }

        void NcsServer_NewUserConnected(NcsUser user)
        {
            user.heartbeat_start();
            lock (user_list)
            {
                user_list.Add(user);
            }
        }

        void NcsServer_UserClosed(NcsUser user, CloseReason reason)
        {
            user.instance_die = true;
            lock (user_list)
            {
                user_list.Remove(user);
            }
        }
        
        void NcsServer_NewRequestReceived(NcsUser user, NcsRequestInfo requestInfo)
        {
            NcsBuffer buffer = new NcsBuffer(requestInfo.Body);
            int signal = buffer.pop_sint16();
            Console.WriteLine(signal);
            if ((requestInfo.Key == 2) || (requestInfo.Key == 3))
            {
                switch (signal)
                {
                    // HeartBeat
                    case Program.signal_heartbeat_first:
                        {
                            NcsBuffer heartbeat_buffer = new NcsBuffer(Program.signal_heartbeat_second, Program.SendToClient);
                            heartbeat_buffer.push_size();
                            user.Send(heartbeat_buffer.write_buffer, 0, heartbeat_buffer.write_offset);
                            user.heartbeat = true;
                        }
                        break;

                    case Program.signal_login:
                        {
                            Console.WriteLine(buffer.pop_string());
                        }
                        break;
                    default:
                        Console.WriteLine("unvaild : " + signal);
                        break;
                }

                if (requestInfo.Key == 3)
                {
                    // Client < - > Client
                    foreach (NcsUser index in user_list)
                    {
                        index.Send(requestInfo.Buffer, 0, requestInfo.Buffer.Length);
                    }
                }
            }
            else
            {
                // Client < - > Client
                foreach(NcsUser index in user_list)
                {
                    index.Send(requestInfo.Buffer, 0, requestInfo.Buffer.Length);
                }
            }
        }

    }
}
