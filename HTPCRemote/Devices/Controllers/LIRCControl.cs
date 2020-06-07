using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace HTPCRemote.Devices.Controllers
{
    class LIRCControl
    {
        public static void RunCmd(string IP, string cmd, string param)
        {
            SocketConnection LIRCsocket = new SocketConnection(IP, "", SocketType.Stream, ProtocolType.Tcp);

            if (LIRCsocket.Connect())
            {
                Thread.Sleep(250);
                LIRCsocket.SendData(Encoding.ASCII.GetBytes("SEND_ONCE " + cmd + " " + param + " \n"));
                LIRCsocket.CloseSocket();
            }
        }
    }
}