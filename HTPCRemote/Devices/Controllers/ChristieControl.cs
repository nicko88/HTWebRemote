using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace HTPCRemote.Devices.Controllers
{
    class ChristieControl
    {
        public static void RunCmd(string IP, string cmd)
        {
            SocketConnection Christiesocket = new SocketConnection(IP, "23", SocketType.Stream, ProtocolType.Tcp);

            if (Christiesocket.Connect())
            {
                Thread.Sleep(100);
                Christiesocket.SendData(Encoding.ASCII.GetBytes(cmd.ToUpper()));
                Christiesocket.CloseSocket();
            }
        }
    }
}