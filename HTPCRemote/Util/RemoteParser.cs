using HTPCRemote.RemoteFile;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;

namespace HTPCRemote.Util
{
    class RemoteParser
    {
        private static string IP = ConfigHelper.GetLocalIPAddress();

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
                string[] files = Directory.GetFiles(ConfigHelper.WorkingPath, "HTPCRemoteButtons*");

                if (files.Length > 1 || files.Length > 0 && ConfigHelper.CheckRegKey(@"SOFTWARE\HTPCRemote", "ShowFileBrowser"))
                {
                    sb.AppendLine(@"<ul class=""nav nav-tabs bg-dark sticky-top"">");

                    foreach (string file in files)
                    {
                        if (file.Contains(".json"))
                        {
                            JObject oRemote = JObject.Parse(File.ReadAllText(file));

                            string remoteNum = (string)oRemote.SelectToken("RemoteID");
                            string remoteName = (string)oRemote.SelectToken("RemoteName");

                            if (string.IsNullOrEmpty(remoteName))
                            {
                                remoteName = remoteNum;
                            }

                            sb.AppendLine(@"<li class=""nav-item"">");
                            if (remoteNum == currentRemoteNum)
                            {
                                sb.AppendLine($@"<a class=""nav-link active bg-dark text-white"" href=""{remoteNum}"">{remoteName}</a>");
                            }
                            else
                            {
                                sb.AppendLine($@"<a class=""nav-link text-muted"" href=""{remoteNum}"">{remoteName}</a>");
                            }
                            sb.AppendLine("</li>");
                        }
                    }

                    if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTPCRemote", "ShowFileBrowser"))
                    {
                        sb.AppendLine($@"<li class=""nav-item""><a class=""nav-link text-muted"" href=""FB"">FB</a></li>");
                    }

                    if (!string.IsNullOrEmpty(YoutubeSearch._searchQ))
                    {
                        sb.AppendLine($@"<li class=""nav-item""><a class=""nav-link text-muted"" href=""FByoutube?play=0"">YT</a></li>");
                    }

                    sb.AppendLine("</ul>");
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
                            groupStarted = false;
                        }

                        sb.AppendFormat("<h4>{0}</h4>" + Environment.NewLine, item.Label);
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
                        string colorClass;
                        switch (item.Color)
                        {
                            case "Blue":
                                colorClass = "btn-primary";
                                break;
                            case "Green":
                                colorClass = "btn-success";
                                break;
                            case "Red":
                                colorClass = "btn-danger";
                                break;
                            case "Orange":
                                colorClass = "btn-warning";
                                break;
                            case "Teal":
                                colorClass = "btn-info";
                                break;
                            case "Grey":
                                colorClass = "btn-secondary";
                                break;
                            case "White":
                                colorClass = "btn-light";
                                break;
                            case "Black":
                                colorClass = "btn-dark";
                                break;
                            default:
                                colorClass = "btn-primary";
                                break;
                        }

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

                        if (!query)
                        {
                            sb.AppendFormat(@"<div class=""nitem"" style=""flex-grow: {0};""><button onclick=""sendbtn('{1}', '{2}', '{3}')"" class=""btn {4}"">{5}</button></div>" + Environment.NewLine, item.RelativeSize, remote.RemoteID, i, item.ConfirmPopup, colorClass, item.Label);
                        }
                        else
                        {
                            sb.AppendFormat(@"<div class=""nitem"" style=""flex-grow: {0};""><button onclick=""sendquery('{1}', '{2}', '{3}', '{4}')"" class=""btn {5}"">{6}</button></div>" + Environment.NewLine, item.RelativeSize, remote.RemoteID, item.Commands[0].DeviceName, item.Commands[0].Cmd, item.ConfirmPopup, colorClass, item.Label);
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

            return sb.ToString();
        }

        private static string GetHTMLHeader(Remote remote)
        {
            string header = ConfigHelper.GetEmbeddedResource("remoteHeader.html");

            if(remote.ButtonHeight > 0)
            {
                header = header.Replace("height: 42px;", $"height: {remote.ButtonHeight}px;");
            }

            if(remote.RemoteBackColor != null)
            {
                header = header.Replace("background-color: black;", $"background-color: {remote.RemoteBackColor};");
                header = header.Replace("border: 2px solid black;", $"border: 2px solid {remote.RemoteBackColor};");
            }

            if (remote.RemoteTextColor != null)
            {
                header = header.Replace("color: white;", $"color: {remote.RemoteTextColor};");
                header = header.Replace("outline: 1px solid grey;", $"outline: 1px solid {remote.RemoteTextColor};");
            }

            return header;
        }
    }
}