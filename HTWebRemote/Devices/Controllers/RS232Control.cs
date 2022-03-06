using System;
using System.IO.Ports;
using System.Threading;

namespace HTWebRemote.Devices.Controllers
{
    class RS232Control
    {
        public static void RunCmd(string COMport, string cmd)
        {
            try
            {
                using (SerialPort sp = new SerialPort(COMport, 9600, Parity.None, 8, StopBits.One))
                {
                    string newLine = "";

                    if(cmd.Contains("<CR>"))
                    {
                        newLine = "\r";
                        cmd = cmd.Replace("<CR>", "");
                    }
                    if(cmd.Contains("<LF>"))
                    {
                        newLine = "\n";
                        cmd = cmd.Replace("<LF>", "");
                    }
                    if (cmd.Contains("<CRLF>"))
                    {
                        newLine = "\r\n";
                        cmd = cmd.Replace("<CRLF>", "");
                    }

                    sp.Open();
                    sp.Write(cmd + newLine);
                    Thread.Sleep(100);
                    sp.Close();
                }
            }
            catch(Exception e)
            {
                Util.ErrorHandler.SendError($"Cannot connect to {COMport}\n\n{e.Message}");
            }
        }
    }
}