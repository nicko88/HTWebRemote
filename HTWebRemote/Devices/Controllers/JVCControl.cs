using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace HTWebRemote.Devices.Controllers
{
    class JVCControl
    {
        public static void RunCmd(string IP, string cmd, string param, string pass)
        {
            byte[] PJREQ = Encoding.ASCII.GetBytes("PJREQ");

            if (!string.IsNullOrEmpty(pass))
            {
                byte[] withPass = Encoding.ASCII.GetBytes($"PJREQ_{pass}");

                PJREQ = new byte[16];
                for(int i = 0; i < withPass.Length; i++)
                {
                    PJREQ[i] = withPass[i];
                }
            }

            SocketConnection JVCsocket = new SocketConnection(IP, "20554", SocketType.Stream, ProtocolType.Tcp);

            if (JVCsocket.Connect())
            {
                string PJ_OK = JVCsocket.ReceiveData();
                if (PJ_OK == "PJ_OK")
                {
                    JVCsocket.SendData(PJREQ);
                    string PJACK = JVCsocket.ReceiveData();
                    if (PJACK == "PJACK")
                    {
                        byte[] message;

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
                                Util.ErrorHandler.SendError($"Invalid JVC parameter\n\n{e.AllMessages()}");
                            }

                            //end
                            cmdBuilder.Add(0x0A);

                            message = cmdBuilder.ToArray();
                        }

                        JVCsocket.SendData(message);
                        JVCsocket.CloseSocket();
                    }
                    else
                    {
                        Util.ErrorHandler.SendError($"PJACK not recieved.");
                    }
                }
                else
                {
                    Util.ErrorHandler.SendError($"PJ_OK not recieved.");
                }
            }
        }
    }
}