using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;

namespace HTPCRemote.Util
{
    class FileBrowserV2
    {
        private static string savedLocation = "";

        public static string LoadFileBrowser(HttpListenerRequest request)
        {
            bool footer = true;

            StringBuilder page = new StringBuilder();

            string header;
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("filebrowserHeader.html"));

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                header = reader.ReadToEnd();
            }
            page.Append(header);

            page.Append(GetHTMLRemoteTabs());

            string currentPath = "";
            string search = "";
            try
            {
                currentPath = Base64Decode(request.QueryString["path"]);
                search = request.QueryString["search"];
            }
            catch { }

            if (request.RawUrl == "/FB")
            {
                currentPath = savedLocation;
            }
            else if (request.RawUrl.Contains("FBback"))
            {
                if (savedLocation != null && savedLocation.LastIndexOf(@"\") > 0)
                {
                    currentPath = savedLocation.Remove(savedLocation.LastIndexOf(@"\"));

                    List<string> paths = File.ReadLines($@"{ConfigHelper.WorkingPath}\HTPCRemoteBrowsePaths.txt").ToList();
                    List<string> fileList = new List<string>();

                    foreach (string path in paths)
                    {
                        if (path.Contains(currentPath))
                        {
                            string newPath = currentPath;
                            currentPath = path;

                            if (newPath.Length < path.Length)
                            {
                                currentPath = null;
                            }
                        }
                    }
                }
            }
            else if (request.RawUrl.Contains("FByoutube"))
            {
                string postData = null;
                if (request.HasEntityBody)
                {
                    using (Stream body = request.InputStream)
                    {
                        using (StreamReader reader = new StreamReader(body, request.ContentEncoding))
                        {
                            postData = reader.ReadToEnd();
                        }
                    }
                }

                if (!string.IsNullOrEmpty(postData))
                {
                    string autoplay = "";
                    if (postData.Contains("?"))
                    {
                        autoplay = "&autoplay=1";
                    }
                    else
                    {
                        autoplay = "?autoplay=1";
                    }

                    if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTPCRemote", "YoutubeUseWebBrowser"))
                    {
                        Process.Start($"{postData}{autoplay}");
                        Thread.Sleep(5000);
                        Devices.Controllers.KeysControl.RunCmd("f", "", false);
                    }
                    else
                    {
                        string YTMediaPlayerPath = ConfigHelper.GetRegKey(@"SOFTWARE\HTPCRemote", "YoutubeMediaPlayer");
                        if (string.IsNullOrEmpty(YTMediaPlayerPath))
                        {
                            Process.Start($"{postData}{autoplay}");
                            Thread.Sleep(5000);
                            Devices.Controllers.KeysControl.RunCmd("f", "", false);
                        }
                        else
                        {
                            postData = postData.Replace("https", "http");
                            Process.Start(YTMediaPlayerPath, $@"""{postData}""");
                        }
                    }
                }
            }

            savedLocation = currentPath;

            if (!string.IsNullOrEmpty(currentPath) && string.IsNullOrEmpty(search))
            {
                FileAttributes attr = new FileAttributes();
                bool validPath = true;
                try
                {
                    attr = File.GetAttributes(currentPath);
                }
                catch
                {
                    validPath = false;
                }

                if (!attr.HasFlag(FileAttributes.Directory) && validPath)
                {
                    string FBMediaPlayerPath = ConfigHelper.GetRegKey(@"SOFTWARE\HTPCRemote", "FileBrowserMediaPlayer");
                    if (string.IsNullOrEmpty(FBMediaPlayerPath))
                    {
                        Process.Start(currentPath);
                    }
                    else
                    {
                        string smb = "";
                        if (FBMediaPlayerPath.Contains("kodi.exe") && currentPath.StartsWith("\\"))
                        {
                            smb = "smb:";
                        }

                        Process.Start(FBMediaPlayerPath, $@"""{smb}{currentPath}""");
                    }

                    savedLocation = currentPath.Remove(currentPath.LastIndexOf(@"\"));

                    page.Clear();
                    page.Append(GetRemotePage());
                    footer = false;
                }
                else
                {
                    page.Append(@"<span style=""color: white; font-size: 15px;"">Search for files in the folders below that contain this exact phrase (single word works best)</span>");
                    page.Append(@"<form method=""GET"">");
                    page.Append($@"<input type=""hidden"" value=""{Base64Encode(currentPath)}"" id=""path"" name=""path"">");
                    page.Append(@"<input type=""text"" id=""search"" name=""search"" class=""form-control mb-2 mr-sm-2 form-check-inline"" style=""width: 200px; display: inline;""><button type=""submit"" id=""submit"" class=""btn btn-primary"">Search</button>");
                    page.Append("</form>");

                    page.Append(@"<button onclick=""window.location.href='FBback'; "" class=""btn btn-primary"" style=""margin-right: 4px;"">Back</button>");
                    page.Append(@"<button onclick=""window.location.href='FBhome'; "" class=""btn btn-primary"">Home</button>");

                    try
                    {
                        string[] dirs = Directory.GetDirectories(currentPath);
                        List<string> dirList = new List<string>(dirs);
                        dirList.Sort();

                        page.Append(@"<div class=""list-group"">");
                        if (dirList.Count > 0)
                        {
                            page.Append(@"<h4 style=""color: white;"">Folders</h4>");
                        }
                        foreach (string path in dirList)
                        {
                            page.Append($@"<a href=""FB?path={Base64Encode(path)}"" style=""padding: 4px 8px;"" class=""list-group-item list-group-item-action list-group-item-dark"">{Path.GetFileName(path)}</a>");
                        }
                    }
                    catch { }

                    try
                    {
                        string[] files = Directory.GetFiles(currentPath);
                        List<string> fileList = new List<string>(files);
                        fileList.Sort();

                        page.Append(@"<div class=""list-group"">");
                        if (fileList.Count > 0)
                        {
                            page.Append(@"<h4 style=""color: white;"">Files</h4>");
                        }
                        foreach (string path in fileList)
                        {
                            page.Append($@"<a href=""FB?path={Base64Encode(path)}"" style=""padding: 4px 8px;"" class=""list-group-item list-group-item-action list-group-item-dark"">{Path.GetFileName(path)}</a>");
                        }
                    }
                    catch { }
                }
            }
            else if (!string.IsNullOrEmpty(currentPath) && !string.IsNullOrEmpty(search))
            {
                try
                {
                    string[] files = Directory.GetFiles(currentPath, "*" + search + "*", SearchOption.AllDirectories);
                    List<string> fileList = new List<string>(files);
                    fileList.Sort();

                    page.Append(@"<div class=""list-group"">");
                    if (fileList.Count > 0)
                    {
                        page.Append(@"<h4 style=""color: white;"">Files</h4>");
                    }
                    foreach (string path in fileList)
                    {
                        page.Append($@"<a href=""FB?path={Base64Encode(path)}"" style=""padding: 4px 8px;"" class=""list-group-item list-group-item-action list-group-item-dark"">{Path.GetFileName(path)}</a>");
                    }
                    if (fileList.Count == 0)
                    {
                        page.Append($@"<p style=""color: white;"">No results found for ""{search}"".</p>");
                    }
                }
                catch { }
            }
            else if (string.IsNullOrEmpty(currentPath) && !string.IsNullOrEmpty(search))
            {
                try
                {
                    List<string> paths = File.ReadLines($@"{ConfigHelper.WorkingPath}\HTPCRemoteBrowsePaths.txt").ToList();
                    List<string> fileList = new List<string>();

                    foreach (string path in paths)
                    {
                        string[] files = Directory.GetFiles(path, $"*{search}*", SearchOption.AllDirectories);
                        fileList.AddRange(files.ToList());
                    }

                    fileList.Sort();

                    page.Append(@"<div class=""list-group"">");
                    if (fileList.Count > 0)
                    {
                        page.Append(@"<h4 style=""color: white;"">Files</h4>");
                    }
                    foreach (string path in fileList)
                    {
                        page.Append($@"<a href=""FB?path={Base64Encode(path)}"" style=""padding: 4px 8px;"" class=""list-group-item list-group-item-action list-group-item-dark"">{Path.GetFileName(path)}</a>");
                    }
                    if (fileList.Count == 0)
                    {
                        page.Append($@"<p style=""color: white;"">No results found for ""{search}"".</p>");
                    }
                }
                catch { }
            }
            else
            {
                page.Append(@"<span style=""color: white; font-size: 15px;"">Search for files in the folders below that contain this exact phrase (single word works best)</span>");
                page.Append(@"<form style=""margin-bottom: 0px"" method=""GET"">");
                page.Append(@"<input type=""text"" id=""search"" name=""search"" class=""form-control mb-2 mr-sm-2 form-check-inline"" style=""width: 200px; display: inline;""><button type=""submit"" id=""submit"" class=""btn btn-primary"">Search</button>");
                page.Append("</form>");

                if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTPCRemote", "EnableYoutube"))
                {
                    page.Append(@"<span style=""color: white; font-size: 15px;"">YouTube:</span>");
                    page.Append("<br />");
                    page.Append(@"<input type=""text"" id=""youtube"" name=""youtube"" class=""form-control mb-2 mr-sm-2 form-check-inline"" style=""width: 200px; display: inline;"">");
                    page.Append(@"<button onclick=""youtube()"" class=""btn btn-primary"">Play</button>");
                    page.Append("<br />");
                }

                page.Append(@"<button onclick=""window.location.href='FBback'; "" class=""btn btn-primary"" style=""margin-right: 4px;"">Back</button>");
                page.Append(@"<button onclick=""window.location.href='FBhome'; "" class=""btn btn-primary"">Home</button>");

                try
                {
                    List<string> paths = File.ReadLines($@"{ConfigHelper.WorkingPath}\HTPCRemoteBrowsePaths.txt").ToList();

                    page.Append(@"<div class=""list-group"">");
                    if (paths.Count > 0)
                    {
                        page.Append(@"<h4 style=""color: white;"">Folders</h4>");
                    }
                    foreach (string path in paths)
                    {
                        page.Append($@"<a href=""FB?path={Base64Encode(path)}"" style=""padding: 4px 8px;"" class=""list-group-item list-group-item-action list-group-item-dark"">{path}</a>");
                    }
                }
                catch
                {
                    page.Append(@"<p style=""color: white;"">No valid file browser paths configured.</p>");
                    page.Append(@"<p style=""color: white;"">Please click 'Edit File Browser Paths' and add at least 1 path.</p>");
                }
            }

            if (footer)
            {
                page.Append("</div>");
                page.Append("</div></body></html>");
            }

            return page.ToString();
        }

        public static string GetRemotePage()
        {
            string htmlPage;
            string remoteNum = ConfigHelper.GetRegKey(@"SOFTWARE\HTPCRemote", "FileBrowserRemote");

            if (remoteNum.Length == 1)
            {
                htmlPage = RemoteParser.GetRemoteHTML(remoteNum, true);
            }
            else
            {
                htmlPage = RemoteParser.GetRemoteHTML("1", true);
            }

            return htmlPage;
        }

        public static string GetHTMLRemoteTabs()
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                string[] files = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "HTPCRemoteButtons*");

                if (files.Length > 0)
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
                            sb.AppendLine($@"<a class=""nav-link text-muted"" href=""{remoteNum}"">{remoteName}</a>");
                            sb.AppendLine("</li>");
                        }
                    }

                    sb.AppendLine($@"<li class=""nav-item""><a class=""nav-link bg-dark active text-white"" href=""FB"">FB</a></li>");

                    sb.AppendLine("</ul>");
                }
            }
            catch { }

            return sb.ToString();
        }

        public static string Base64Encode(string plainText)
        {
            if (!string.IsNullOrEmpty(plainText))
            {
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                return System.Convert.ToBase64String(plainTextBytes);
            }
            return "";
        }

        public static string Base64Decode(string base64EncodedData)
        {
            if (!string.IsNullOrEmpty(base64EncodedData))
            {
                byte[] base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                return Encoding.UTF8.GetString(base64EncodedBytes);
            }
            return null;
        }
    }
}