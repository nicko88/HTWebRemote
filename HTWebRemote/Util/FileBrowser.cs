using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HTWebRemote.Util
{
    class FileBrowserV2
    {
        private static string _savedLocation = "";
        private static string _YTstring;
        private static string _prevSearch;

        public static string LoadFileBrowser(HttpListenerRequest request)
        {
            StringBuilder page = new StringBuilder();

            string header = ConfigHelper.GetEmbeddedResource("filebrowserHeader.html");
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
                currentPath = _savedLocation;
            }
            else if (request.RawUrl.Contains("FBback"))
            {
                if(_savedLocation != null && _savedLocation.LastIndexOf(@"\") > 0)
                {
                    currentPath = _savedLocation.Remove(_savedLocation.LastIndexOf(@"\"));

                    if (currentPath.EndsWith(":"))
                    {
                        currentPath = currentPath + @"\";
                    }

                    List<string> paths = File.ReadLines($@"{ConfigHelper.WorkingPath}\HTWebRemoteBrowsePaths.txt").ToList();
                    foreach (string path in paths)
                    {
                        if (path.Contains(_savedLocation.TrimEnd('\\')))
                        {
                            currentPath = null;
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

                string play = request.QueryString["play"];
                if (play != "0")
                {
                    try
                    {
                        if (postData != null)
                        {
                            _YTstring = postData.Split('=')[1];
                        }
                    }
                    catch { }
                }
                else
                {
                    _YTstring = _prevSearch;
                }

                if (!string.IsNullOrEmpty(_YTstring))
                {
                    if(_YTstring.Contains("http"))
                    {
                        _YTstring = HttpUtility.UrlDecode(_YTstring);

                        string autoplay = "?autoplay=1";
                        if (_YTstring.Contains("?"))
                        {
                            autoplay = "&autoplay=1";
                        }

                        if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "YoutubeUseWebBrowser"))
                        {
                            Process.Start($"{_YTstring}{autoplay}");
                            Task.Delay(5000).ContinueWith(_ => Devices.Controllers.KeysControl.RunCmd("f", ""));
                        }
                        else
                        {
                            string YTMediaPlayerPath = ConfigHelper.GetRegKey(@"SOFTWARE\HTWebRemote", "YoutubeMediaPlayer");
                            if (string.IsNullOrEmpty(YTMediaPlayerPath))
                            {
                                Process.Start($"{_YTstring}{autoplay}");
                                Task.Delay(5000).ContinueWith(_ => Devices.Controllers.KeysControl.RunCmd("f", ""));
                            }
                            else
                            {
                                _YTstring = _YTstring.Replace("https", "http");
                                Process.Start(YTMediaPlayerPath, $@"""{_YTstring}""");
                            }
                        }

                        page.Clear();
                        page.Append(GetRemotePage());
                    }
                    else
                    {
                        page.Clear();
                        _prevSearch = _YTstring;
                        page.Append(YoutubeSearch.LoadSearchResults(_YTstring));
                    }

                    return page.ToString();
                }
            }

            _savedLocation = currentPath;

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
                    string FBMediaPlayerPath = ConfigHelper.GetRegKey(@"SOFTWARE\HTWebRemote", "FileBrowserMediaPlayer");
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

                    _savedLocation = currentPath.Remove(currentPath.LastIndexOf(@"\"));

                    page.Clear();
                    page.Append(GetRemotePage());

                    return page.ToString();
                }
                else
                {
                    page.Append(@"<span style=""color: white; font-size: 15px;"">Search for files in the folders below that contain this exact phrase (single word works best)</span>");
                    page.Append(@"<form style=""margin-bottom: 0px"" method=""GET"">");
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
                    List<string> paths = File.ReadLines($@"{ConfigHelper.WorkingPath}\HTWebRemoteBrowsePaths.txt").ToList();
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
                page.Append(@"<input type=""text"" id=""search"" name=""search"" class=""form-control mb-2 mr-sm-2 form-check-inline"" style=""width: 200px; display: inline;"">");
                page.Append(@"<button type=""submit"" id=""submit"" class=""btn btn-primary"">Search</button>");
                page.Append("</form>");

                if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "EnableYoutube"))
                {
                    page.Append(@"<span style=""color: white; font-size: 15px;"">YouTube:</span>");
                    page.Append("<br />");

                    page.Append(@"<form style=""margin-bottom: 0px"" method=""POST"" id=""youtubeform"" action=""FByoutube"">");
                    page.Append(@"<input type=""text"" id=""youtube"" name=""youtube"" class=""form-control mb-2 mr-sm-2 form-check-inline"" style=""width: 200px; display: inline;"">");
                    page.Append(@"<button type=""submit"" id=""submit"" class=""btn btn-primary"">Play / Search</button>");
                    page.Append("</form>");
                }

                page.Append(@"<button onclick=""window.location.href='FBback'; "" class=""btn btn-primary"" style=""margin-right: 4px;"">Back</button>");
                page.Append(@"<button onclick=""window.location.href='FBhome'; "" class=""btn btn-primary"">Home</button>");

                try
                {
                    List<string> paths = File.ReadLines($@"{ConfigHelper.WorkingPath}\HTWebRemoteBrowsePaths.txt").ToList();

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

            page.Append("</div>");
            page.Append("</div></body></html>");

            return page.ToString();
        }

        public static string GetRemotePage()
        {
            string htmlPage;
            string remoteNum = ConfigHelper.GetRegKey(@"SOFTWARE\HTWebRemote", "FileBrowserRemote");

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
                string[] files = Directory.GetFiles(ConfigHelper.WorkingPath, "HTWebRemoteButtons*");

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
                            sb.AppendLine($@"<a class=""nav-link"" href=""{remoteNum}"">{remoteName}</a>");
                            sb.AppendLine("</li>");
                        }
                    }

                    sb.AppendLine($@"<li class=""nav-item""><a class=""nav-link bg-dark active"" href=""FB"">FB</a></li>");

                    if(!string.IsNullOrEmpty(YoutubeSearch._searchQ))
                    {
                        sb.AppendLine($@"<li class=""nav-item""><a class=""nav-link"" href=""FByoutube?play=0"">YT</a></li>");
                    }

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