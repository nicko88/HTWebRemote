using System.Net.Sockets;
using System.Text;

namespace HTWebRemote.Devices.Controllers
{
    class LIRCControl
    {
        public static void RunCmd(string IP, string cmd, string param)
        {
            SocketConnection LIRCsocket = new SocketConnection(IP, "8765", SocketType.Stream, ProtocolType.Tcp);

            if (LIRCsocket.Connect())
            {
                LIRCsocket.SendData(Encoding.ASCII.GetBytes($"SEND_ONCE {cmd} {param} \n"));
                LIRCsocket.CloseSocket();
            }
        }
    }
}