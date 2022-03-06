using System.Net.Sockets;
using System.Text;

namespace HTWebRemote.Devices.Controllers
{
    class HDFuryControl
    {
        public static void RunCmd(string IP, string cmd)
        {
            SocketConnection HDFurySocket = new SocketConnection(IP, "2220", SocketType.Stream, ProtocolType.Tcp);

            if (HDFurySocket.Connect())
            {
                HDFurySocket.SendData(Encoding.ASCII.GetBytes($"{cmd}\r"));
                HDFurySocket.CloseSocket();
            }
        }
    }
}