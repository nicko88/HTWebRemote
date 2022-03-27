using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace HTWebRemote.Devices.Controllers
{
    class PanaProjControl
    {
        public static void RunCmd(string IP, string cmd, string param)
        {
            SocketConnection PanaProjsocket = new SocketConnection(IP, "1024", SocketType.Stream, ProtocolType.Tcp);

            if (PanaProjsocket.Connect())
            {
                string NTCONTROL = PanaProjsocket.ReceiveData();
                if (NTCONTROL.Contains("NTCONTROL"))
                {
                    List<byte> cmdBuilder = new List<byte>();

                    //header
                    cmdBuilder.Add(0x30);
                    cmdBuilder.Add(0x30);

                    //ID
                    cmdBuilder.AddRange(Encoding.ASCII.GetBytes("ADZZ;"));

                    //command
                    cmdBuilder.AddRange(Encoding.ASCII.GetBytes(cmd));

                    //paramater
                    if (!string.IsNullOrEmpty(param))
                    {
                        cmdBuilder.AddRange(Encoding.ASCII.GetBytes($":{param}"));
                    }

                    //end
                    cmdBuilder.Add(0x0d);

                    byte[] message = cmdBuilder.ToArray();

                    PanaProjsocket.SendData(message);
                    PanaProjsocket.CloseSocket();
                }
                else
                {
                    Util.ErrorHandler.SendError($"NTCONTROL not recieved.");
                }
            }
        }
    }
}