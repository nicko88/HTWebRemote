using HTWebRemote.RemoteFile;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace HTWebRemote.Util
{
    class RemoteParser
    {
        public static string GetRemoteHTML(string remoteNum, bool withTabs)
        {
            Remote remote = RemoteJSONLoader.LoadRemoteJSON(remoteNum);

            if (withTabs)
            {
                return GetHTMLHeader(remote) + GetHTMLRemoteTabs(remoteNum) + GenerateHTMLButtons(remote, remoteNum) + Environment.NewLine + "</div><script>null;</script></body></html>";
            }
            else
            {
                return GetHTMLHeader(remote) + GenerateHTMLButtons(remote, remoteNum) + Environment.NewLine + "</div><script>null;</script></body></html>";
            }
        }

        public static string GetHTMLRemoteTabs(string currentRemoteNum)
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                string[] files = Directory.GetFiles(ConfigHelper.WorkingPath, "HTWebRemoteButtons*");

                if (files.Length > 1 || files.Length > 0 && ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "ShowFileBrowser"))
                {
                    List<string> filesList = new List<string>();
                    filesList.AddRange(files);
                    filesList.Sort();

                    sb.AppendLine(@"<div class=""nav-container"">");
                    sb.AppendLine(@"<ul class=""nav nav-tabs sticky-top"">");

                    foreach (string file in filesList)
                    {
                        if (file.Contains(".json"))
                        {
                            JObject oRemote = JObject.Parse(File.ReadAllText(file));

                            string remoteNum = (string)oRemote.SelectToken("RemoteID");
                            string remoteName = (string)oRemote.SelectToken("RemoteName");

                            bool hideRemote = false;
                            try
                            {
                                hideRemote = (bool)oRemote.SelectToken("HideRemote");
                            }
                            catch { }

                            if (!hideRemote)
                            {
                                if (string.IsNullOrEmpty(remoteName))
                                {
                                    remoteName = remoteNum;
                                }

                                sb.AppendLine(@"<li class=""nav-item"">");
                                if (remoteNum == currentRemoteNum)
                                {
                                    sb.AppendLine($@"<a class=""nav-link active"" href=""{remoteNum}"">{remoteName}</a>");
                                }
                                else
                                {
                                    sb.AppendLine($@"<a class=""nav-link"" href=""{remoteNum}"">{remoteName}</a>");
                                }
                                sb.AppendLine("</li>");
                            }
                        }
                    }

                    if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "ShowFileBrowser"))
                    {
                        sb.AppendLine($@"<li class=""nav-item""><a class=""nav-link"" href=""FB"">FB</a></li>");
                    }

                    if (!string.IsNullOrEmpty(YoutubeSearch._searchQ))
                    {
                        sb.AppendLine($@"<li class=""nav-item""><a class=""nav-link"" href=""FByoutube?play=0"">YT</a></li>");
                    }

                    sb.AppendLine("</ul>");
                    sb.AppendLine("</div>");
                    sb.AppendLine();
                }
            }
            catch { }

            return sb.ToString();
        }

        private static string GenerateHTMLButtons(Remote remote, string RemoteNum)
        {
            bool groupStarted = false;
            bool buttonRowStarted = false;
            RemoteItem.RemoteItemType prevItemType = RemoteItem.RemoteItemType.Group;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"<div class=""container body-content"">");

            if (remote.RemoteItems != null)
            {
                for (int i = 0; i < remote.RemoteItems.Count; i++)
                {
                    RemoteItem item = remote.RemoteItems[i];

                    if (item.ItemType == RemoteItem.RemoteItemType.Group)
                    {
                        if (prevItemType == RemoteItem.RemoteItemType.Button || prevItemType == RemoteItem.RemoteItemType.Blank)
                        {
                            sb.AppendLine("</div>");
                            buttonRowStarted = false;
                        }

                        if (groupStarted)
                        {
                            sb.AppendLine("</div>");
                        }

                        string textColor = "#FFFFFF";
                        if(!string.IsNullOrEmpty(item.Color))
                        {
                            textColor = item.Color;
                        }

                        sb.AppendFormat(@"<h4 style=""color: {0};"">{1}</h4>" + Environment.NewLine, textColor, item.Label);
                        sb.AppendLine(@"<div class=""form-group ngroup"">");
                        groupStarted = true;
                        prevItemType = RemoteItem.RemoteItemType.Group;
                    }
                    else if (item.ItemType == RemoteItem.RemoteItemType.Blank)
                    {
                        if (!buttonRowStarted)
                        {
                            sb.AppendLine(@"<div class=""nrow"">");
                        }

                        sb.AppendFormat(@"<div class=""nitem"" style=""flex-grow: {0};""><button class=""btn""></button></div>" + Environment.NewLine, item.RelativeSize);
                        buttonRowStarted = true;
                        prevItemType = RemoteItem.RemoteItemType.Blank;
                    }
                    else if (item.ItemType == RemoteItem.RemoteItemType.NewRow)
                    {
                        if (buttonRowStarted)
                        {
                            sb.AppendLine("</div>");
                        }
                        else if (prevItemType == RemoteItem.RemoteItemType.NewRow)
                        {
                            sb.AppendLine("<br/>");
                        }
                        buttonRowStarted = false;
                        prevItemType = RemoteItem.RemoteItemType.NewRow;
                    }
                    else
                    {
                        string btnColorHex = ConfigHelper.ConvertLegacyColor(item.Color);

                        if (!buttonRowStarted)
                        {
                            sb.AppendLine(@"<div class=""nrow"">");
                        }

                        bool query = false;
                        try
                        {
                            query = item.Commands[0].Cmd.StartsWith("query:");
                        }
                        catch { }

                        string textColor = "#FFFFFF";
                        if(UseDarkColor(btnColorHex, 0.5))
                        {
                            textColor = "#000000";
                        }

                        if (!query)
                        {
                            sb.AppendFormat(@"<div class=""nitem"" style=""flex-grow: {0};""><button onclick=""sendbtn('{1}', '{2}', '{3}')"" class=""btn"" style=""background-color: {4}; color: {5};"">{6}</button></div>" + Environment.NewLine, item.RelativeSize, remote.RemoteID, i, item.ConfirmPopup, btnColorHex, textColor, item.Label);
                        }
                        else
                        {
                            sb.AppendFormat(@"<div class=""nitem"" style=""flex-grow: {0};""><button onclick=""sendquery('{1}', '{2}', '{3}', '{4}')"" class=""btn"" style=""background-color: {5}; color: {6};"">{7}</button></div>" + Environment.NewLine, item.RelativeSize, remote.RemoteID, item.Commands[0].DeviceName, item.Commands[0].Cmd, item.ConfirmPopup, btnColorHex, textColor, item.Label);
                        }

                        buttonRowStarted = true;
                        prevItemType = RemoteItem.RemoteItemType.Button;
                    }
                }
            }
            else
            {
                sb.AppendLine($@"<p style=""color: white;"">No remote found for Remote #{RemoteNum}</p>");
            }

            if (groupStarted)
            {
                sb.AppendLine("</div>");
            }

            sb.AppendLine("</div>");
            return sb.ToString();
        }

        private static string GetHTMLHeader(Remote remote)
        {
            string header = ConfigHelper.GetEmbeddedResource("remoteHeader.html");

            if(string.IsNullOrEmpty(remote.RemoteBackColor))
            {
                remote.RemoteBackColor = "#000000";
            }

            int strength = remote.RemoteShadingStrength == null ? 1 : remote.RemoteShadingStrength.Value;
            int navstrength = strength;
            if (strength == 0)
            {
                navstrength = 1;
            }
            Color navColor = AddColors(ColorTranslator.FromHtml(remote.RemoteBackColor), Color.FromArgb(0.15 * 255 * navstrength > 255 ? 255 : Convert.ToInt32(0.15 * 255 * navstrength), 255, 255, 255));

            header = header.Replace("background-color: black;", $"background-color: {remote.RemoteBackColor};");

            if (UseDarkColor(remote.RemoteBackColor, 0.11))
            {
                header = header.Replace("background-color: rgba(255, 255, 255, 0.15);", $"background-color: rgba(0, 0, 0, {0.15*strength});");
                header = header.Replace("background-color: rgba(255, 255, 255, 0.10);", $"background-color: rgba(0, 0, 0, {0.10*strength});");
                header = header.Replace("background-color: #ffffff26;", $"background-color: rgba(0, 0, 0, {0.15 * navstrength});");
                header = header.Replace("background-color: #ffffff1a;", $"background-color: rgba(0, 0, 0, {0.10 * navstrength});");

                navColor = AddColors(ColorTranslator.FromHtml(remote.RemoteBackColor), Color.FromArgb(0.15 * 255 * navstrength > 255 ? 255 : Convert.ToInt32(0.15 * 255 * navstrength), 0, 0, 0));
            }
            else
            {
                header = header.Replace("background-color: rgba(255, 255, 255, 0.15);", $"background-color: rgba(255, 255, 255, {0.15 * strength});");
                header = header.Replace("background-color: rgba(255, 255, 255, 0.10);", $"background-color: rgba(255, 255, 255, {0.10 * strength});");
                header = header.Replace("background-color: #ffffff26;", $"background-color: rgba(255, 255, 255, {0.15 * navstrength});");
                header = header.Replace("background-color: #ffffff1a;", $"background-color: rgba(255, 255, 255, {0.10 * navstrength});");
            }

            if (UseDarkColor(ColorTranslator.ToHtml(navColor), 0.4))
            {
                header = header.Replace("--navTextColor: white;", "--navTextColor: black;");
            }

            if (strength == 0)
            {
                header = header.Replace("border-radius: 0 0 6px 6px;", "border-radius: 6px;");
                if (UseDarkColor(remote.RemoteBackColor, 0.5))
                {
                    header = header.Replace("border: 0px solid gray;", "border: 1px solid black;");
                }
                else
                {
                    header = header.Replace("border: 0px solid gray;", "border: 1px solid gray;");
                }
            }

            if (remote.ButtonHeight > 0)
            {
                header = header.Replace("height: 42px;", $"height: {remote.ButtonHeight}px;");
            }

            if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "BottomTabs"))
            {
                header = header.Replace("flex-direction: column;", "flex-direction: column-reverse;");
                header = header.Replace("justify-content: flex-start;", "justify-content: space-between;");
            }

            return header;
        }

        private static bool UseDarkColor(string hexColor, double threshold)
        {
            Color c = ColorTranslator.FromHtml(hexColor);
            double luminance = (0.299 * c.R + 0.587 * c.G + 0.114 * c.B) / 255;

            if (luminance > threshold)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static Color AddColors(Color background, Color alphaMask)
        {
            if (alphaMask.R == 255)
            {
                return Color.FromArgb(255,
                                      background.R + alphaMask.A > 255 ? 255 : background.R + alphaMask.A,
                                      background.G + alphaMask.A > 255 ? 255 : background.G + alphaMask.A,
                                      background.B + alphaMask.A > 255 ? 255 : background.B + alphaMask.A);
            }
            else
            {
                return Color.FromArgb(255,
                                      background.R - alphaMask.A < 0 ? 0 : background.R - alphaMask.A,
                                      background.G - alphaMask.A < 0 ? 0 : background.G - alphaMask.A,
                                      background.B - alphaMask.A < 0 ? 0 : background.B - alphaMask.A);
            }
        }
    }
}