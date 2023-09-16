using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace HTWebRemote.Devices.Controllers
{
    class RS232Control
    {
        public static void RunCmd(string COMport, string cmd, string param)
        {
            try
            {
                using (SerialPort sp = new SerialPort(COMport, 9600, Parity.None, 8, StopBits.One))
                {
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

                    sp.Open();
                    sp.Write(cmdBytes, 0, cmdBytes.Length);
                    Thread.Sleep(100);
                    sp.Close();
                    sp.Dispose();
                }
            }
            catch(Exception e)
            {
                Util.ErrorHandler.SendError($"Cannot connect to {COMport}\n\n{e.AllMessages()}");
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