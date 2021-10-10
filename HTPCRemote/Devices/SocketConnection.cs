using System;
using System.Net.Sockets;
using System.Net;
using HTPCRemote.Util;
using System.Windows.Forms;

namespace HTPCRemote.Devices
{
    class SocketConnection
    {
        private Socket socket;
        private IPEndPoint remoteEndPoint;

        public SocketConnection(string IP, string port, SocketType socketType, ProtocolType protocolType)
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, socketType, protocolType);

                string[] IPport = IP.Split(':');

                int iPort;
                if (IPport.Length > 1)
                {
                    iPort = Convert.ToInt32(IPport[1], 10);
                }
                else
                {
                    iPort = Convert.ToInt32(port, 10);
                }

                IPAddress remoteIPAddress = IPAddress.Parse(IPport[0]);
                remoteEndPoint = new IPEndPoint(remoteIPAddress, iPort);
            }
            catch(Exception e)
            {
                if(ConfigHelper.CheckRegKey(@"SOFTWARE\HTPCRemote", "ShowErrors"))
                {
                    MessageBox.Show($"Cannot setup connection for {IP}:{port} {protocolType}\n\n{e.Message}", "Error");
                }
            }
        }

        public bool Connect()
        {
            try
            {
                socket.Connect(remoteEndPoint);
            }
            catch(Exception e)
            {
                if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTPCRemote", "ShowErrors"))
                {
                    MessageBox.Show($"Cannot connect to device at {remoteEndPoint.Address}:{remoteEndPoint.Port} {socket.ProtocolType}\n\n{e.Message}", "Error");
                }
            }

            return socket.Connected;
        }

        public void SendData(byte[] data)
        {
            try
            {
                socket.Send(data);
            }
            catch(Exception e)
            {
                if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTPCRemote", "ShowErrors"))
                {
                    MessageBox.Show($"Cannot send Command: {data} to device at {remoteEndPoint.Address}:{remoteEndPoint.Port} {socket.ProtocolType}\n\n{e.Message}", "Error");
                }
            }
        }

        public void CloseSocket()
        {
            socket?.Close();
        }
    }
}