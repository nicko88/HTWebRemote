using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace HTPCRemote.Devices.Controllers
{
    class OppoControl
    {
        public static void RunCmd(string IP, string cmd, string param)
        {
            SocketConnection OppoSocket = new SocketConnection(IP, "23", SocketType.Stream, ProtocolType.Tcp);

            if (OppoSocket.Connect())
            {
                Thread.Sleep(100);

                string command = cmd;
                if (!string.IsNullOrEmpty(param))
                {
                    command = command + " " + param;
                }

                OppoSocket.SendData(Encoding.ASCII.GetBytes("#" + command + "\r"));
                OppoSocket.CloseSocket();
            }
        }
    }
}