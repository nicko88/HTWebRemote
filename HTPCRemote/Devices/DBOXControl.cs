using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;

namespace HTPCRemote.Devices
{
    class DBOXControl
    {
        public static void RunCmd(string IP, string cmd, string param, bool showErrors)
        {
            Socket socket = null;

            if (string.IsNullOrEmpty(param))
            {
                param = "0";
            }

            try
            {
                byte[] message = null;
                if (cmd == "WSTOP")
                {
                    message = new byte[] { 0x02, 0x57, 0x53, 0x54, 0x4F, 0x50, 0x03 };
                }
                else
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    int alPort = Convert.ToInt32("61555", 10);

                    System.Net.IPAddress remoteIPAddress = System.Net.IPAddress.Parse(IP);
                    System.Net.IPEndPoint remoteEndPoint = new System.Net.IPEndPoint(remoteIPAddress, alPort);

                    socket.Connect(remoteEndPoint);

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

                socket.Send(message);
            }
            catch (Exception e)
            {
                if (showErrors)
                {
                    MessageBox.Show("Cannot connect to D-BOX at " + IP + ":" + "61555" + "\n\n" + e.Message, "Error");
                }
            }
            finally
            {
                socket?.Close();
            }
        }
    }
}