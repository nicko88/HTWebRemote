using System;
using System.Diagnostics;
using System.IO;

namespace HTWebRemote.Devices.Controllers
{
    class WinControl
    {
        public static void RunCmd(string path, string param)
        {
            if (path.StartsWith("setvol") || path.StartsWith("editvol") || path.StartsWith("mutevol"))
            {
                VolControl(path);
            }
            else
            {
                Process process = new Process();
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;

                if(!string.IsNullOrEmpty(param))
                {
                    process.StartInfo.Arguments = param;
                }

                try
                {
                    if (File.Exists(path))
                    {
                        process.StartInfo.FileName = path;
                    }
                    else
                    {
                        process.StartInfo.FileName = $"{Util.ConfigHelper.WorkingPath}\\{path}";
                    }
                }
                catch
                {
                    Util.ErrorHandler.SendError($"Cannot find file to open or run: \n\n{process.StartInfo.FileName}");
                }
                try
                {
                    process.Start();
                }
                catch
                {
                    Util.ErrorHandler.SendError($"Cannot open or run file: \n\n{process.StartInfo.FileName}");
                }
            }
        }

        private static void VolControl(string volCmd)
        {
            if(volCmd == "mutevol")
            {
                Util.WindowsAudioControl.MuteVolume();
            }
            else
            {
                string[] volInfo = volCmd.Split('=');

                if(volInfo[0] == "setvol")
                {
                    Util.WindowsAudioControl.SetVolume(Convert.ToInt32(volInfo[1]));
                }
                else if(volInfo[0] == "editvol")
                {
                    Util.WindowsAudioControl.AddSubtractVolume(Convert.ToInt32(volInfo[1]));
                }
            }
        }

        public static string getvol()
        {
            return Util.WindowsAudioControl.GetVolume().ToString() + "%";
        }
    }
}