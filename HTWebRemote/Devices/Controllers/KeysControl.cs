using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HTWebRemote.Devices.Controllers
{
    class KeysControl
    {
        [DllImport("USER32.DLL")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void RunCmd(string keys, string app)
        {
            if (!string.IsNullOrEmpty(app))
            {
                try
                {
                    Process process = Process.GetProcessesByName(app).FirstOrDefault();

                    ShowWindow(process.MainWindowHandle, 1);
                    SetForegroundWindow(process.MainWindowHandle);
                }
                catch (Exception e)
                {
                    Util.ErrorHandler.SendError($"Cannot find program: {app} to send keys to.\n\n{e.AllMessages()}");
                }
            }

            keys = keys.Replace("ctrl", "^");
            keys = keys.Replace("shift", "+");
            keys = keys.Replace("alt", "%");
            keys = keys.Replace("{SPACE}", " ");

            try
            {
                SendKeys.SendWait(keys);
            }
            catch (Exception e)
            {
                Util.ErrorHandler.SendError($"Error sending key: {keys}\n\n{e.AllMessages()}");
            }
        }
    }
}