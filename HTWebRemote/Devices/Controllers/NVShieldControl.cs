using HTWebRemote.Util;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace HTWebRemote.Devices.Controllers
{
    class NVShieldControl
    {
        private static Dictionary<string, (string, string)> _apps;
        private static Dictionary<string, (string, string)> Apps
        {
            get
            {
                _apps = new Dictionary<string, (string, string)>
                {
                    { "netflix", ("shell monkey -p com.netflix.ninja 1", "shell am force-stop com.netflix.ninja") },
                    { "plex", ("shell monkey -p com.plexapp.android 1", "shell am force-stop com.plexapp.android") },
                    { "youtube", ("shell monkey -p com.google.android.youtube.tv 1", "shell am force-stop com.google.android.youtube.tv") },
                    { "disney+", ("shell monkey -p com.disney.disneyplus 1", "shell am force-stop com.disney.disneyplus") },
                    { "hulu", ("shell monkey -p com.hulu.livingroomplus 1", "shell am force-stop com.hulu.livingroomplus") },
                    { "spotify", ("shell monkey -p com.spotify.tv.android 1", "shell am force-stop com.spotify.tv.android") },
                    { "hbomax", ("shell monkey -p com.hbo.hbonow 1", "shell am force-stop com.hbo.hbonow") },
                    { "twitch", ("shell monkey -p tv.twitch.android.app 1", "shell am force-stop tv.twitch.android.app") },
                    { "kodi", ("shell monkey -p org.xbmc.kodi 1", "shell am force-stop org.xbmc.kodi") },
                    { "criterion", ("shell monkey -p com.criterionchannel 1", "shell am force-stop com.criterionchannel") },
                    { "pbs", ("shell monkey -p com.pbs.video 1", "shell am force-stop com.pbs.video") },
                    { "kanopy", ("shell monkey -p com.kanopy.tvapp 1", "shell am force-stop com.kanopy.tvapp") },
                    { "puffin_browser", ("shell monkey -p com.cloudmosa.puffinTV 1", "shell am force-stop com.cloudmosa.puffinTV") },
                    { "remote_locator", ("shell monkey -p com.nvidia.remotelocator 1", "shell am force-stop com.nvidia.remotelocator") },
                    { "amazon_video", ("shell am start -n com.amazon.amazonvideo.livingroom/com.amazon.ignition.IgnitionActivity", "shell am force-stop com.amazon.amazonvideo.livingroom") },
                    { "amazon_music", ("shell am start -n com.amazon.music.tv/com.amazon.music.MainActivity", "shell am force-stop com.amazon.music.tv") },
                    { "appletv+", ("shell am start -n com.apple.atve.androidtv.appletv/.MainActivity", "shell am force-stop com.apple.atve.androidtv.appletv") },
                    { "movies_anywhere", ("shell am start -n com.moviesanywhere.goo/com.disney.brooklyn.tv.main.DeepLinkActivity", "shell am force-stop com.moviesanywhere.goo") },
                    { "vimeo", ("shell am start -n com.vimeo.android.videoapp/.core.MainActivity", "shell am force-stop com.vimeo.android.videoapp") },
                    { "vudu", ("shell am start -n air.com.vudu.air.DownloaderTablet/.TvMainActivity", "shell am force-stop air.com.vudu.air.DownloaderTablet") }
                };

                return _apps;
            }
        }

        public static void RunCmd(string IP, string cmd, string param)
        {
            ExecuteCmd($"connect {IP}:5555", "");
            ExecuteCmd(cmd, param);
        }

        private static void ExecuteCmd(string cmd, string param)
        {
            string arguments = cmd;

            if (cmd.StartsWith("KEYCODE"))
            {
                arguments = $"shell input keyevent {cmd}";
            }
            else if (cmd == "start")
            {
                if (Apps.TryGetValue(param, out (string, string) appcmd))
                {
                    arguments = appcmd.Item1;
                }
                else if(param.Contains("/"))
                {
                    arguments = $"shell am start -n {param}";
                }
                else
                {
                    arguments = $"shell monkey -p {param} 1";
                }

            }
            else if (cmd == "stop")
            {
                if (Apps.TryGetValue(param, out (string, string) appcmd))
                {
                    arguments = appcmd.Item2;
                }
                else
                {
                    arguments = $"shell am force-stop {param}";
                }
            }

            try
            {
                Process process = new Process();

                process.StartInfo.FileName = Path.Combine(ConfigHelper.WorkingPath, "adb.exe");
                process.StartInfo.Arguments = arguments;

                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                process.WaitForExit();
            }
            catch
            {
                if(ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "ShowErrors"))
                {
                    MessageBox.Show($"Unable to locate: {Path.Combine(ConfigHelper.WorkingPath, "adb.exe")}", "Error");
                }
            }
        }
    }
}