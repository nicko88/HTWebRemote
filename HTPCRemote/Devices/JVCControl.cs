using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace HTPCRemote.Devices
{
    class JVCControl
    {
        public static void RunCmd(string IP, string cmd, string param, bool showErrors)
        {
            Socket socket = null;

            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                int port = Convert.ToInt16("20554", 10);

                System.Net.IPAddress remoteIPAddress = System.Net.IPAddress.Parse(IP);
                System.Net.IPEndPoint remoteEndPoint = new System.Net.IPEndPoint(remoteIPAddress, port);

                socket.Connect(remoteEndPoint);
                System.Threading.Thread.Sleep(250);

                socket.Send(Encoding.ASCII.GetBytes("PJREQ"));
                System.Threading.Thread.Sleep(250);

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
                    catch(Exception e)
                    {
                        MessageBox.Show("Invalid parameter" + "\n\n" + e.Message, "Error");
                    }

                    //end
                    cmdBuilder.Add(0x0A);

                    message = cmdBuilder.ToArray();
                }

                socket.Send(message);
            }
            catch (Exception e)
            {
                if (showErrors)
                {
                    MessageBox.Show("Cannot connect to JVC at " + IP + ":" + "20554" + "\n\n" + e.Message, "Error");
                }
            }
            finally
            {
                socket?.Close();
            }
        }
    }
}