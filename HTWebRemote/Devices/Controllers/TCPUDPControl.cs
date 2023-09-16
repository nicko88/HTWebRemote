using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace HTWebRemote.Devices.Controllers
{
    class TCPUDPControl
    {
        public static void RunCmd(bool tcp, string IP, string cmd, string param)
        {
            SocketConnection Socket;
            if (tcp)
            {
                Socket = new SocketConnection(IP, "0", SocketType.Stream, ProtocolType.Tcp);
            }
            else
            {
                Socket = new SocketConnection(IP, "0", SocketType.Dgram, ProtocolType.Udp);
            }

            byte[] cmdBytes;
            if (param == "hex")
            {
                cmdBytes = HexStringToBytes(cmd);
            }
            else
            {
                cmd = cmd.Replace("<CR>", "\r");
                cmd = cmd.Replace("<LF>", "\n");
                cmd = cmd.Replace("<CRLF>", "\r\n");

                cmdBytes = Encoding.ASCII.GetBytes(cmd);
            }

            if (Socket.Connect())
            {
                Thread.Sleep(100);
                Socket.SendData(cmdBytes);
                Thread.Sleep(100);

                Socket.CloseSocket();
            }
        }

        private static byte[] HexStringToBytes(string hexString)
        {
            string[] hexVals = hexString.Replace("0x", "").Split(new char[] { ' ', ',' });

            List<byte> bytes = new List<byte>();
            try
            {
                foreach (string hex in hexVals)
                {
                    bytes.Add(Convert.ToByte(hex, 16));
                }
            }
            catch (Exception e)
            {
                Util.ErrorHandler.SendError($"Error converting hex values.\n\n{e.AllMessages()}");
            }

            return bytes.ToArray();
        }
    }
}