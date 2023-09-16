using System;
using System.Windows.Forms;
using WebOsTv.Net;
using WebOsTv.Net.Responses.Apps;
using WebOsTv.Net.Responses.Tv;
using WebOsTv.Net.Services;

namespace HTWebRemote.Devices.Controllers
{
    class LGwebOSControl
    {
        public static async void RunCmd(string IP, string cmd, string param, string ssl)
        {
            if(string.IsNullOrEmpty(ssl))
            {
                ssl = "False";
            }

            try
            {
                Service service = new Service();
                await service.ConnectAsync(IP, Convert.ToBoolean(ssl));

                SendCmd(service, cmd, param);
                service.Close();
            }
            catch (Exception e)
            {
                Util.ErrorHandler.SendError($"Error sending command to webOS.\n\n{e.AllMessages()}");
            }
        }

        public static async void SendCmd(Service service, string cmd, string param)
        {
            try
            {
                switch (cmd)
                {
                    case "menu":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Menu);
                        break;
                    case "home":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Home);
                        break;
                    case "enter":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Enter);
                        break;
                    case "back":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Back);
                        break;
                    case "info":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Info);
                        break;
                    case "exit":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Exit);
                        break;
                    case "up":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Up);
                        break;
                    case "down":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Down);
                        break;
                    case "left":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Left);
                        break;
                    case "right":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Right);
                        break;
                    case "red":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Red);
                        break;
                    case "green":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Green);
                        break;
                    case "yellow":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Yellow);
                        break;
                    case "blue":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Blue);
                        break;
                    case "asterisk":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Asterisk);
                        break;
                    case "play":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Play);
                        break;
                    case "pause":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Pause);
                        break;
                    case "stop":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Stop);
                        break;
                    case "fastforward":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.FastForward);
                        break;
                    case "rewind":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Rewind);
                        break;
                    case "captions":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Cc);
                        break;
                    case "myapps":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.MyApps);
                        break;
                    case "gotonext":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.GoToNext);
                        break;
                    case "gotoprev":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.GoToPrev);
                        break;
                    case "livezoom":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.LiveZoom);
                        break;
                    case "aspectratio":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.AspectRatio);
                        break;
                    case "favorites":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Favorites);
                        break;
                    case "qmenu":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.QMenu);
                        break;
                    case "recent":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Recent);
                        break;
                    case "ezpic":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.EzPic);
                        break;
                    case "ezadjust":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.EzAdjust);
                        break;
                    case "instart":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.InStart);
                        break;
                    case "inputhub":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.InputHub);
                        break;
                    case "screenremote":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.ScreenRemote);
                        break;
                    case "search":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.Search);
                        break;
                    case "mute":
                        await service.Audio.MuteAsync();
                        break;
                    case "unmute":
                        await service.Audio.UnmuteAsync();
                        break;
                    case "volup":
                        await service.Audio.VolumeUpAsync();
                        break;
                    case "voldown":
                        await service.Audio.VolumeDownAsync();
                        break;
                    case "setvol":
                        await service.Audio.SetVolumeAsync(Convert.ToInt32(param));
                        break;
                    case "chanup":
                        await service.Tv.ChannelUpAsync();
                        break;
                    case "chandown":
                        await service.Tv.ChannelDownAsync();
                        break;
                    case "openapp":
                        await service.Apps.LaunchAsync(param);
                        break;
                    case "closeapp":
                        await service.Apps.CloseAsync(param);
                        break;
                    case "youtubevideo":
                        await service.Apps.LaunchYouTubeVideoAsync(param);
                        break;
                    case "weburl":
                        await service.Apps.LaunchBrowserAsync(param);
                        break;
                    case "poweroff":
                        await service.Control.SendIntentAsync(ControlService.ControlIntent.PowerOff);
                        break;
                    case "applist":
                        ShowAppList(service);
                        break;
                    default:
                        break;
                }
            }
            catch(Exception e)
            {
                Util.ErrorHandler.SendError($"Error processing command:\n\ncmd={cmd}\nparam={param}\n\n{e.AllMessages()}");
            }
        }

        private static async void ShowAppList(Service service)
        {
            ListLaunchPointsResponse.LaunchPoint[] applist = await service.Apps.ListAsync();
            ExternalInputListResponse.Device[] inputlist = await service.Tv.ListInputsAsync();

            System.Drawing.Size size = new System.Drawing.Size(500, 10 + 20 * (applist.Length + inputlist.Length));
            Form textbox = new Form();

            textbox.FormBorderStyle = FormBorderStyle.FixedDialog;
            textbox.ClientSize = size;
            textbox.Text = "Available Apps";

            RichTextBox rtb = new RichTextBox();
            rtb.Size = new System.Drawing.Size(size.Width - 10, 20 * (applist.Length + inputlist.Length));
            rtb.Location = new System.Drawing.Point(5, 5);
            rtb.Font = new System.Drawing.Font("Consolas", 10);
            textbox.Controls.Add(rtb);

            string apps = "";
            foreach (ListLaunchPointsResponse.LaunchPoint app in applist)
            {
                apps += $"{app.Title}: appid={app.Id}\n";
            }
            apps += "\nInputs:\n";
            foreach (ExternalInputListResponse.Device input in inputlist)
            {
                apps += $"{input.Label}: appid={input.AppId}\n";
            }

            rtb.Text = apps;

            textbox.StartPosition = FormStartPosition.CenterParent;
            textbox.ShowDialog();
        }
    }
}