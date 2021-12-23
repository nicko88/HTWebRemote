using System.Net.Sockets;
using System.Text;

namespace HTWebRemote.Devices.Controllers
{
    class ZoomControl
    {
        public static void RunCmd(string IP, string cmd)
        {
            SocketConnection Zoomsocket = new SocketConnection(IP, "4769", SocketType.Stream, ProtocolType.Tcp);

            string functionType = "";
            if (cmd.StartsWith("fn"))
            {
                functionType = "5100";
            }
            else if (cmd.StartsWith("ex"))
            {
                functionType = "5110";
            }
            else if (cmd.StartsWith("nv"))
            {
                functionType = "5130";
            }

            if (Zoomsocket.Connect())
            {
                Zoomsocket.SendData(Encoding.ASCII.GetBytes($"{functionType} {cmd}\r\n"));
                Zoomsocket.CloseSocket();
            }
        }
    }
}