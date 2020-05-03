using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HTPCRemote.Devices
{
    class KeysControl
    {
        [DllImport("USER32.DLL")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void RunCmd(string keys, string app, bool showErrors)
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
                    if (showErrors)
                    {
                        MessageBox.Show("Cannot find program: " + app + " to send keys to." + "\n\n" + e.Message, "Error");
                    }
                }
            }

            keys = keys.Replace("ctrl", "^");
            keys = keys.Replace("shift", "+");
            keys = keys.Replace("alt", "%");
            keys = keys.Replace("{SPACE}", " ");

            SendKeys.SendWait(keys);
        }
    }
}