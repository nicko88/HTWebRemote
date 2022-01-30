using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;

namespace HTWebRemote.Devices.Controllers
{
    class DBOXControl
    {
        public static void RunCmd(string IP, string cmd, string param)
        {
            SocketConnection DBOXsocket = new SocketConnection(IP, "61555", SocketType.Stream, ProtocolType.Tcp);

            if (DBOXsocket.Connect())
            {
                Thread.Sleep(250);
                if (string.IsNullOrEmpty(param))
                {
                    param = "0";
                }

                byte[] message;
                if (cmd == "WSTOP")
                {
                    message = new byte[] { 0x02, 0x57, 0x53, 0x54, 0x4F, 0x50, 0x03 };
                }
                else
                {
                    List<byte> cmdBuilder = new List<byte>();

                    //start byte
                    cmdBuilder.Add(0x02);
                    //cmdBytes
                    cmdBuilder.AddRange(System.Text.Encoding.ASCII.GetBytes(cmd));
                    //separater byte
                    cmdBuilder.Add(0x1E);
                    //param bytes
                    cmdBuilder.AddRange(System.Text.Encoding.ASCII.GetBytes(param));
                    //end byte
                    cmdBuilder.Add(0x03);

                    message = cmdBuilder.ToArray();
                }

                DBOXsocket.SendData(message);
                DBOXsocket.CloseSocket();
            }
        }
    }
}