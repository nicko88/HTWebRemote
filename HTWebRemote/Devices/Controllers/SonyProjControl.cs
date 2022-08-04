using System.Net.Sockets;
using System.Text;
using System.Security.Cryptography;

namespace HTWebRemote.Devices.Controllers
{
    class SonyProjControl
    {
        public static void RunCmd(string IP, string cmd, string param, string password)
        {
            SocketConnection Sonysocket = new SocketConnection(IP, "53595", SocketType.Stream, ProtocolType.Tcp);

            if (Sonysocket.Connect())
            {
                string AUTH = Sonysocket.ReceiveData().Replace("\r\n", "");

                if (!AUTH.Contains("NOKEY"))
                {
                    using (SHA256 sha256Hash = SHA256.Create())
                    {
                        byte[] hashBytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes($"{AUTH}{password}"));

                        StringBuilder hashString = new StringBuilder();
                        for (int i = 0; i < hashBytes.Length; i++)
                        {
                            hashString.Append(hashBytes[i].ToString("x2"));
                        }

                        Sonysocket.SendData(Encoding.ASCII.GetBytes($"{hashString}\r\n"));
                        string OK = Sonysocket.ReceiveData();

                        if (!OK.Contains("OK"))
                        {
                            Util.ErrorHandler.SendError($"Authentication failed for password: {password}");
                        }
                    }
                }

                Sonysocket.SendData(Encoding.ASCII.GetBytes($"{cmd} {param}\r\n"));
                Sonysocket.CloseSocket();
            }
        }
    }
}