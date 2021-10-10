using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HTPCRemote.Devices.Controllers
{
    class JVCControl
    {
        public static void RunCmd(string IP, string cmd, string param)
        {
            SocketConnection JVCsocket = new SocketConnection(IP, "20554", SocketType.Stream, ProtocolType.Tcp);

            if (JVCsocket.Connect())
            {
                JVCsocket.SendData(Encoding.ASCII.GetBytes("PJREQ"));
                Thread.Sleep(50);

                byte[] message = null;

                //remote codes
                if (cmd.Length == 2 && string.IsNullOrEmpty(param))
                {
                    byte RCByte1 = Convert.ToByte(cmd[0]);
                    byte RCByte2 = Convert.ToByte(cmd[1]);

                    message = new byte[] { 0x21, 0x89, 0x01, 0x52, 0x43, 0x37, 0x33, RCByte1, RCByte2, 0x0A };
                }
                else
                {
                    List<byte> cmdBuilder = new List<byte>();

                    //!(operation)
                    cmdBuilder.Add(0x21);
                    //PJ
                    cmdBuilder.Add(0x89);
                    //individual
                    cmdBuilder.Add(0x01);

                    //command bytes
                    cmdBuilder.AddRange(Encoding.ASCII.GetBytes(cmd));

                    try
                    {
                        //+ turns into space via querystring
                        if ((param.StartsWith("+") || param.StartsWith(" ")) && param.Length > 1)
                        {
                            int num = Convert.ToInt32(param);
                            string hex = num.ToString("X4");
                            cmdBuilder.AddRange(Encoding.ASCII.GetBytes(hex));
                        }
                        else if (param.StartsWith("-") && param.Length > 1)
                        {
                            int num = Convert.ToInt32(param);
                            string hex = num.ToString("X4");
                            cmdBuilder.AddRange(Encoding.ASCII.GetBytes(hex.Substring(4)));
                        }
                        else
                        {
                            cmdBuilder.AddRange(Encoding.ASCII.GetBytes(param));
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Invalid JVC parameter\n\n{e.Message}", "Error");
                    }

                    //end
                    cmdBuilder.Add(0x0A);

                    message = cmdBuilder.ToArray();
                }

                JVCsocket.SendData(message);
                JVCsocket.CloseSocket();
            }
        }
    }
}