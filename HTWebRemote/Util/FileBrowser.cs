using Newtonsoft.Json.Linq;
using System;
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
        private static string _sortBy;
        private static string _sortDir;

        public static string LoadFileBrowser(HttpListenerRequest request)
        {
            StringBuilder page = new StringBuilder();

            string header = ConfigHelper.GetEmbeddedResource("filebrowserHeader.html");

            if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "BottomTabs"))
            {
                header = header.Replace("flex-direction: column;", "flex-direction: column-reverse;");
                header = header.Replace("justify-content: flex-start;", "justify-content: space-between;");
            }

            page.Append(header);
            page.Append(GetHTMLRemoteTabs());
            page.AppendLine(@"<div class=""container body-content"">");

            string currentPath = "";
            string search = "";
            _sortBy = "Name";
            _sortDir = "ASC";
            try
            {
                currentPath = Base64Decode(request.QueryString["path"]);
                search = request.QueryString["search"];

                if(!string.IsNullOrEmpty(request.QueryString["sortby"]))
                {
                    _sortBy = request.QueryString["sortby"];
                }
                if (!string.IsNullOrEmpty(request.QueryString["sortdir"]))
                {
                    _sortDir = request.QueryString["sortdir"];
                }

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
                        string[] vals = path.Split(',');
                        if (vals[0].Contains(_savedLocation.TrimEnd('\\')))
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
                    page.Append(@"<span style=""color: white; font-size: 15px;"">Search: (single word works best)</span>");
                    page.Append(@"<form style=""margin-bottom: 0px"" method=""GET"">");
                    page.Append(@"<div class=""nrow"">");
                    page.Append($@"<input type=""hidden"" value=""{Base64Encode(currentPath)}"" id=""path"" name=""path"">");
                    page.Append(@"<input type=""text"" id=""search"" name=""search"" class=""nitem form-control mb-2 mr-sm-2 form-check-inline"" style=""flex-grow: 2;""><button type=""submit"" id=""submit"" class=""nitem btn btn-primary"" style=""flex-grow: 1;"">Search</button>");
                    page.Append(@"</div>");
                    page.Append("</form>");

                    page.Append(@"<div class=""nrow"">");
                    page.Append(@"<button onclick=""window.location.href='FBback'; "" class=""nitem btn btn-primary"" style=""flex-grow: 2; margin-right: 4px;"">Back</button>");
                    page.Append(@"<button onclick=""window.location.href='FBhome'; "" class=""nitem btn btn-primary"" style=""flex-grow: 2;"">Home</button>");

                    string sortByChange;
                    if (_sortBy == "Name")
                    {
                        sortByChange = "&sortby=Date&sortdir=DESC";
                    }
                    else
                    {
                        sortByChange = "&sortby=Name&sortdir=ASC";
                    }

                    string sortDirChange;
                    if (_sortDir == "ASC")
                    {
                        sortDirChange = $"&sortby={_sortBy}&sortdir=DESC";
                    }
                    else
                    {
                        sortDirChange = $"&sortby={_sortBy}&sortdir=ASC";
                    }

                    page.Append(@"<span class=""nitem"" style=""flex-grow: 3; color: White; text-align: end; padding-top: 5;"">Sorted By:</span>");
                    page.Append($@"<button onclick=""window.location.href=window.location.origin + '/FB' + '?path={Base64Encode(currentPath)}' + '{sortByChange}'; "" class=""nitem btn btn-primary"" style=""flex-grow: 2; margin-right: 4px;"">{_sortBy}</button>");
                    page.Append($@"<button onclick=""window.location.href=window.location.origin + '/FB' + '?path={Base64Encode(currentPath)}' + '{sortDirChange}'; "" class=""nitem btn btn-primary"" style=""flex-grow: 2;"">{_sortDir}</button>");
                    page.Append(@"</div>");

                    try
                    {
                        DirectoryInfo[] dirs = GetDirectories(currentPath);

                        page.Append(@"<div class=""list-group"">");
                        if (dirs.Length > 0)
                        {
                            page.Append(@"<h4 style=""color: white;"">Folders</h4>");
                        }
                        foreach (DirectoryInfo dir in dirs)
                        {
                            page.Append($@"<a href=""FB?path={Base64Encode(dir.FullName)}"" style=""padding: 4px 8px;"" class=""list-group-item list-group-item-action list-group-item-dark"">{dir.Name}</a>");
                        }
                    }
                    catch { }

                    try
                    {
                        FileInfo[] files = GetFiles(currentPath);

                        page.Append(@"<div class=""list-group"">");
                        if (files.Length > 0)
                        {
                            page.Append(@"<h4 style=""color: white;"">Files</h4>");
                        }
                        foreach (FileInfo file in files)
                        {
                            page.Append($@"<a href=""FB?path={Base64Encode(file.FullName)}"" style=""padding: 4px 8px;"" class=""list-group-item list-group-item-action list-group-item-dark"">{file.Name}</a>");
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
                        string[] vals = path.Split(',');
                        string[] files = Directory.GetFiles(vals[0], $"*{search}*", SearchOption.AllDirectories);
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
                page.Append(@"<span style=""color: white; font-size: 15px;"">Search: (single word works best)</span>");
                page.Append(@"<form style=""margin-bottom: 0px"" method=""GET"">");
                page.Append(@"<div class=""nrow"">");
                page.Append(@"<input type=""text"" id=""search"" name=""search"" class=""nitem form-control mb-2 mr-sm-2 form-check-inline"" style=""flex-grow: 2;"">");
                page.Append(@"<button type=""submit"" id=""submit"" class=""nitem btn btn-primary"" style=""flex-grow: 1;"">Search</button>");
                page.Append(@"</div>");
                page.Append("</form>");

                if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "EnableYoutube"))
                {
                    page.Append(@"<span style=""color: white; font-size: 15px;"">YouTube:</span>");
                    page.Append("<br />");

                    page.Append(@"<form style=""margin-bottom: 0px"" method=""POST"" id=""youtubeform"" action=""FByoutube"">");
                    page.Append(@"<div class=""nrow"">");
                    page.Append(@"<input type=""text"" id=""youtube"" name=""youtube"" class=""nitem form-control mb-2 mr-sm-2 form-check-inline"" style=""flex-grow: 2;"">");
                    page.Append(@"<button type=""submit"" id=""submit"" class=""nitem btn btn-primary"" style=""flex-grow: 1;"">Play/Search</button>");
                    page.Append(@"</div>");
                    page.Append("</form>");
                }

                page.Append(@"<div class=""nrow"">");
                page.Append(@"<button onclick=""window.location.href='FBback'; "" class=""nitem btn btn-primary"" style=""flex-grow: 2; margin-right: 4px;"">Back</button>");
                page.Append(@"<button onclick=""window.location.href='FBhome'; "" class=""nitem btn btn-primary"" style=""flex-grow: 2;"">Home</button>");

                string sortByChange;
                if (_sortBy == "Name")
                {
                    sortByChange = "&sortby=Date&sortdir=DESC";
                }
                else
                {
                    sortByChange = "&sortby=Name&sortdir=ASC";
                }

                string sortDirChange;
                if (_sortDir == "ASC")
                {
                    sortDirChange = $"&sortby={_sortBy}&sortdir=DESC";
                }
                else
                {
                    sortDirChange = $"&sortby={_sortBy}&sortdir=ASC";
                }

                page.Append(@"<span class=""nitem"" style=""flex-grow: 3; color: White; text-align: end; padding-top: 5;"">Sorted By:</span>");
                page.Append($@"<button onclick=""window.location.href=window.location.origin + '/FB' + '?path={Base64Encode(currentPath)}' + '{sortByChange}'; "" class=""nitem btn btn-primary"" style=""flex-grow: 2; margin-right: 4px;"">{_sortBy}</button>");
                page.Append($@"<button onclick=""window.location.href=window.location.origin + '/FB' + '?path={Base64Encode(currentPath)}' + '{sortDirChange}'; "" class=""nitem btn btn-primary"" style=""flex-grow: 2;"">{_sortDir}</button>");
                page.Append(@"</div>");

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
                        string[] vals = path.Split(',');
                        string alias = vals[0];
                        if(vals.Length > 1)
                        {
                            alias = vals[1];
                        }
                        page.Append($@"<a href=""FB?path={Base64Encode(vals[0])}"" style=""padding: 4px 8px;"" class=""list-group-item list-group-item-action list-group-item-dark"">{alias}</a>");
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
                            sb.AppendLine($@"<a class=""nav-link"" href=""{remoteNum}"">{remoteName}</a>");
                            sb.AppendLine("</li>");
                        }
                    }
                }

                sb.AppendLine($@"<li class=""nav-item""><a class=""nav-link active"" href=""FB"">FB</a></li>");

                if (!string.IsNullOrEmpty(YoutubeSearch._searchQ))
                {
                    sb.AppendLine($@"<li class=""nav-item""><a class=""nav-link"" href=""FByoutube?play=0"">YT</a></li>");
                }

                sb.AppendLine("</ul>");
                sb.AppendLine("</div>");
                sb.AppendLine();
            }

            catch { }

            return sb.ToString();
        }

        private static FileInfo[] GetFiles(string path)
        {
            FileInfo[] files;
            DirectoryInfo info = new DirectoryInfo(path);

            if (_sortBy == "Name")
            {
                if (_sortDir == "ASC")
                {
                    files = info.GetFiles().OrderBy(x => x.Name).ToArray();
                }
                else
                {
                    files = info.GetFiles().OrderByDescending(x => x.Name).ToArray();
                }
            }
            else
            {
                if (_sortDir == "ASC")
                {
                    files = info.GetFiles().OrderBy(x => x.CreationTime).ToArray();
                }
                else
                {
                    files = info.GetFiles().OrderByDescending(x => x.CreationTime).ToArray();
                }
            }

            return files;
        }

        private static DirectoryInfo[] GetDirectories(string path)
        {
            DirectoryInfo[] dirs;
            DirectoryInfo info = new DirectoryInfo(path);

            if (_sortBy == "Name")
            {
                if (_sortDir == "ASC")
                {
                    dirs = info.GetDirectories().OrderBy(x => x.Name).ToArray();
                }
                else
                {
                    dirs = info.GetDirectories().OrderByDescending(x => x.Name).ToArray();
                }
            }
            else
            {
                if (_sortDir == "ASC")
                {
                    dirs = info.GetDirectories().OrderBy(x => x.CreationTime).ToArray();
                }
                else
                {
                    dirs = info.GetDirectories().OrderByDescending(x => x.CreationTime).ToArray();
                }
            }

            return dirs;
        }

        public static string Base64Encode(string plainText)
        {
            if (!string.IsNullOrEmpty(plainText))
            {
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                return Convert.ToBase64String(plainTextBytes);
            }
            return "";
        }

        public static string Base64Decode(string base64EncodedData)
        {
            if (!string.IsNullOrEmpty(base64EncodedData))
            {
                byte[] base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
                return Encoding.UTF8.GetString(base64EncodedBytes);
            }
            return null;
        }
    }
}