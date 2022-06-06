using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace HTWebRemote.Devices.Controllers
{
    class LyngdorfControl
    {
        public static void RunCmd(string IP, string cmd, string param)
        {
            SocketConnection LyngdorfSocket = new SocketConnection(IP, "84", SocketType.Stream, ProtocolType.Tcp);

            if (LyngdorfSocket.Connect())
            {
                try
                {
                    if (cmd == "lipsync")
                    {
                        string curLipsync = GetValue(IP, "!LIPSYNC?");
                        int newLipSync = Convert.ToInt32(curLipsync) + Convert.ToInt32(param);
                        cmd = $"!LIPSYNC({newLipSync})";
                    }
                }
                catch (Exception e)
                {
                    Util.ErrorHandler.SendError($"Error adjusting lipsync.\n\n{e.Message}");
                }

                LyngdorfSocket.SendData(Encoding.ASCII.GetBytes($"{cmd}\r"));
                LyngdorfSocket.CloseSocket();
            }
        }

        public static string query(string IP, string cmd)
        {
            return GetValue(IP, cmd);
        }

        private static string GetValue(string IP, string cmd)
        {
            string value = "err";
            Util.TelnetConnection conn = null;

            try
            {
                conn = new Util.TelnetConnection(IP, 84);
                conn.Write(cmd);
                Thread.Sleep(100);

                string strData = conn.Read();
                value = Between(strData, '(', ')');

                if (cmd.Contains("!VOL?"))
                {
                    try
                    {
                        double vol = Convert.ToDouble(value);
                        value = (vol / 10d).ToString();
                    }
                    catch { }
                }

                conn.Close();

                return value;
            }
            catch (Exception e)
            {
                Util.ErrorHandler.SendError($"Cannot connect to Lyngdorf at {IP}:84\n\n{e.Message}");
            }
            finally
            {
                conn?.Close();
            }

            return value;
        }

        private static string Between(string input, char start, char end)
        {
            string output;
            int Pos1 = input.IndexOf(start) + 1;
            int Pos2 = input.IndexOf(end);
            output = input.Substring(Pos1, Pos2 - Pos1);
            return output;
        }
    }
}