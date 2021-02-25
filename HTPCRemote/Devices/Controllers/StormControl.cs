using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace HTPCRemote.Devices.Controllers
{
    class StormControl
    {
        public static void RunCmd(string IP, string cmd)
        {
            SocketConnection Stormsocket = new SocketConnection(IP, "23", SocketType.Stream, ProtocolType.Tcp);

            if (Stormsocket.Connect())
            {
                Thread.Sleep(250);
                Stormsocket.SendData(Encoding.ASCII.GetBytes(cmd + "\n"));
                Stormsocket.CloseSocket();
            }
        }
    }
}