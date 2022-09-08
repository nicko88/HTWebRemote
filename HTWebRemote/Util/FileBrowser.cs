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
    class FileBrowser
    {
        private static string _savedLocation = "";
        private static string _YTstring;
        private static string _prevSearch;
        private static string _sortBy;
        private static string _sortDir;

        private static string nameASC = "";
        private static string nameDESC = "";
        private static string dateASC = "";
        private static string dateDESC = "";

        public static string LoadFileBrowser(HttpListenerRequest request)
        {
            StringBuilder page = new StringBuilder();

            string header = ConfigHelper.GetEmbeddedResource("filebrowserHeader.html");

            if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "BottomTabs"))
            {
                header = header.Replace("flex-direction: column;", "flex-direction: column-reverse;");
                header = header.Replace("justify-content: flex-start;", "justify-content: space-between;");
            }

            string itemRowHeight = ConfigHelper.GetRegKey(@"SOFTWARE\HTWebRemote", "ItemRowHeight");
            if (!string.IsNullOrEmpty(itemRowHeight))
            {
                header = header.Replace("height: 34px;", $"height: {itemRowHeight}px;");
            }

            page.AppendLine(header);
            page.AppendLine(GetHTMLRemoteTabs());
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

            nameASC = "";
            nameDESC = "";
            dateASC = "";
            dateDESC = "";
            if (_sortBy == "Name")
            {
                if(_sortDir == "ASC")
                {
                    nameASC = "selected";
                }
                else
                {
                    nameDESC = "selected";
                }
            }
            else
            {
                if (_sortDir == "ASC")
                {
                    dateASC = "selected";
                }
                else
                {
                    dateDESC = "selected";
                }
            }

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
                        page.AppendLine(GetRemotePage());
                    }
                    else
                    {
                        page.Clear();
                        _prevSearch = _YTstring;
                        page.AppendLine(YoutubeSearch.LoadSearchResults(_YTstring));
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
                    page.AppendLine(GetRemotePage());

                    return page.ToString();
                }
                else
                {
                    page.Append(GetPageControls(currentPath, true, false));

                    try
                    {
                        DirectoryInfo[] dirs = GetDirectories(currentPath);

                        page.AppendLine(@"<div class=""list-group"">");
                        if (dirs.Length > 0)
                        {
                            page.AppendLine(@"<h4 style=""color: white;"">Folders</h4>");
                        }
                        foreach (DirectoryInfo dir in dirs)
                        {
                            page.AppendLine($@"<a href=""FB?path={Base64Encode(dir.FullName)}"" class=""row-item list-group-item list-group-item-action list-group-item-dark"">{dir.Name}</a>");
                        }
                    }
                    catch { }

                    try
                    {
                        FileInfo[] files = GetFiles(currentPath);

                        page.AppendLine(@"<div class=""list-group"">");
                        if (files.Length > 0)
                        {
                            page.AppendLine(@"<h4 style=""color: white;"">Files</h4>");
                        }
                        foreach (FileInfo file in files)
                        {
                            page.AppendLine($@"<a href=""FB?path={Base64Encode(file.FullName)}"" class=""row-item list-group-item list-group-item-action list-group-item-dark"">{file.Name}</a>");
                        }
                    }
                    catch { }
                }
            }
            else if (!string.IsNullOrEmpty(currentPath) && !string.IsNullOrEmpty(search))
            {
                page.Append(GetPageControls(currentPath, false, false));

                try
                {
                    string[] files = Directory.GetFiles(currentPath, "*" + search + "*", SearchOption.AllDirectories);
                    List<string> fileList = new List<string>(files);
                    fileList.Sort();

                    page.AppendLine(@"<div class=""list-group"">");
                    if (fileList.Count > 0)
                    {
                        page.AppendLine(@"<h4 style=""color: white;"">Files</h4>");
                    }
                    foreach (string path in fileList)
                    {
                        page.AppendLine($@"<a href=""FB?path={Base64Encode(path)}"" class=""row-item list-group-item list-group-item-action list-group-item-dark"">{Path.GetFileName(path)}</a>");
                    }
                    if (fileList.Count == 0)
                    {
                        page.AppendLine($@"<p style=""color: white;"">No results found for ""{search}"".</p>");
                    }
                }
                catch { }
            }
            else if (string.IsNullOrEmpty(currentPath) && !string.IsNullOrEmpty(search))
            {
                page.Append(GetPageControls(currentPath, false, false));

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

                    page.AppendLine(@"<div class=""list-group"">");
                    if (fileList.Count > 0)
                    {
                        page.AppendLine(@"<h4 style=""color: white;"">Files</h4>");
                    }
                    foreach (string path in fileList)
                    {
                        page.AppendLine($@"<a href=""FB?path={Base64Encode(path)}"" class=""row-item list-group-item list-group-item-action list-group-item-dark"">{Path.GetFileName(path)}</a>");
                    }
                    if (fileList.Count == 0)
                    {
                        page.AppendLine($@"<p style=""color: white;"">No results found for ""{search}"".</p>");
                    }
                }
                catch { }
            }
            else
            {
                page.Append(GetPageControls(currentPath, true, true));

                try
                {
                    List<string> paths = File.ReadLines($@"{ConfigHelper.WorkingPath}\HTWebRemoteBrowsePaths.txt").ToList();

                    page.AppendLine(@"<div class=""list-group"">");
                    if (paths.Count > 0)
                    {
                        page.AppendLine(@"<h4 style=""color: white;"">Folders</h4>");
                    }
                    foreach (string path in paths)
                    {
                        string[] vals = path.Split(',');
                        string alias = vals[0];
                        if(vals.Length > 1)
                        {
                            alias = vals[1];
                        }
                        page.AppendLine($@"<a href=""FB?path={Base64Encode(vals[0])}"" class=""row-item list-group-item list-group-item-action list-group-item-dark"">{alias}</a>");
                    }
                }
                catch
                {
                    page.AppendLine(@"<p style=""color: white;"">No valid file browser folders configured.</p>");
                    page.AppendLine(@"<p style=""color: white;"">Please click 'Edit File Browser' and add at least one folder.</p>");
                }
            }

            page.AppendLine("</div>");
            page.AppendLine("</div></body></html>");

            return page.ToString();
        }

        public static string GetRemotePage()
        {
            string htmlPage;
            string remoteNum = ConfigHelper.GetRegKey(@"SOFTWARE\HTWebRemote", "FileBrowserRemote");

            if(remoteNum == "None")
            {
                htmlPage = "<script>history.back()</script>";
            }
            else if (remoteNum.Length == 1)
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
                string[] remoteFiles = Directory.GetFiles(ConfigHelper.WorkingPath, "HTWebRemoteButtons*").CustomSort().ToArray();

                sb.AppendLine(@"<div class=""nav-container"">");
                sb.AppendLine(@"<ul class=""nav nav-tabs sticky-top"">");

                foreach (string file in remoteFiles)
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

                sb.AppendLine($@"<li class=""nav-item""><a class=""nav-link active"" href=""FB"">");
                sb.AppendLine($@"<svg width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">");
                sb.AppendLine($@"<path d=""M16.5 12C19 12 21 14 21 16.5C21 17.38 20.75 18.21 20.31 18.9L23.39 22L22 23.39L18.88 20.32C18.19 20.75 17.37 21 16.5 21C14 21 12 19 12 16.5C12 14 14 12 16.5 12ZM16.5 14C15.837 14 15.2011 14.2634 14.7322 14.7322C14.2634 15.2011 14 15.837 14 16.5C14 17.163 14.2634 17.7989 14.7322 18.2678C15.2011 18.7366 15.837 19 16.5 19C17.163 19 17.7989 18.7366 18.2678 18.2678C18.7366 17.7989 19 17.163 19 16.5C19 15.837 18.7366 15.2011 18.2678 14.7322C17.7989 14.2634 17.163 14 16.5 14ZM9 4L11 6H19C19.5304 6 20.0391 6.21071 20.4142 6.58579C20.7893 6.96086 21 7.46957 21 8V11.81C19.7909 10.6469 18.1778 9.99803 16.5 10C14.7761 10 13.1228 10.6848 11.9038 11.9038C10.6848 13.1228 10 14.7761 10 16.5C10 17.79 10.37 19 11 20H3C2.46957 20 1.96086 19.7893 1.58579 19.4142C1.21071 19.0391 1 18.5304 1 18V6C1 4.89 1.89 4 3 4H9Z"" fill=""white"" />");
                sb.AppendLine("</svg></a></li>");

                if (!string.IsNullOrEmpty(YoutubeSearch._searchQ))
                {
                    sb.AppendLine($@"<li class=""nav-item""><a class=""nav-link"" href=""FByoutube?play=0"">");
                    sb.AppendLine($@"<svg width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">");
                    sb.AppendLine($@"<path d=""M19.615 3.184c-3.604-.246-11.631-.245-15.23 0-3.897.266-4.356 2.62-4.385 8.816.029 6.185.484 8.549 4.385 8.816 3.6.245 11.626.246 15.23 0 3.897-.266 4.356-2.62 4.385-8.816-.029-6.185-.484-8.549-4.385-8.816zm-10.615 12.816v-8l8 3.993-8 4.007z"" fill=""white"" />");
                    sb.AppendLine("</svg></a></li>");
                }

                sb.AppendLine("</ul>");
                sb.AppendLine("</div>");
                sb.AppendLine();
            }

            catch { }

            return sb.ToString();
        }

        private static string GetPageControls(string currentPath, bool showSearch, bool showYoutube)
        {
            StringBuilder sb = new StringBuilder();

            if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "EnableYoutube") && showYoutube)
            {
                sb.AppendLine($@"<form style=""margin-bottom: 0px"" method=""POST"" id=""youtubeform"" action=""FByoutube"">");
                sb.AppendLine($@"<div class=""search-row"">");
                sb.AppendLine($@"<div class=""input-group"">");
                sb.AppendLine($@"<div class=""input-group-prepend"">");
                sb.AppendLine($@"<span class=""input-group-text"" id=""inputGroup-sizing-default"">YouTube</span>");
                sb.AppendLine($@"</div>");
                sb.AppendLine($@"<input type=""text"" id=""youtube"" name=""youtube"" class=""form-control"" placeholder=""YouTube link or search"">");
                sb.AppendLine($@"</div>");
                sb.AppendLine($@"<button type=""submit"" id=""submit"" class=""btn btn-primary"">Go</button>");
                sb.AppendLine($@"</div>");
                sb.AppendLine($@"</form>");
                sb.AppendLine($@"<hr class=""mb-3""/>");
            }

            if (showSearch)
            {
                sb.AppendLine($@"<form style=""margin-bottom: 0px"" method=""GET"">");
                sb.AppendLine($@"<div class=""search-row"">");
                sb.AppendLine($@"<div class=""input-group"">");
                sb.AppendLine($@"<div class=""input-group-prepend"">");
                sb.AppendLine($@"<span class=""input-group-text"" id=""inputGroup-sizing-default"">Search</span>");
                sb.AppendLine($@"</div>");
                sb.AppendLine($@"<input type=""hidden"" value=""{Base64Encode(currentPath)}"" id=""path"" name=""path"">");
                sb.AppendLine($@"<input type=""text"" id=""search"" name=""search"" class=""form-control"" placeholder=""Single word works best""> ");
                sb.AppendLine($@"</div>");
                sb.AppendLine($@"<button type=""submit"" id=""submit"" class=""btn btn-primary"">");
                sb.AppendLine($@"<svg width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">");
                sb.AppendLine($@"<path d=""M9.99997 2.5C11.3979 2.49994 12.7681 2.89061 13.9559 3.62792C15.1436 4.36523 16.1016 5.41983 16.7218 6.6727C17.342 7.92558 17.5997 9.32686 17.4658 10.7184C17.3319 12.11 16.8117 13.4364 15.964 14.548L20.707 19.293C20.8863 19.473 20.9904 19.7144 20.9982 19.9684C21.006 20.2223 20.9168 20.4697 20.7487 20.6603C20.5807 20.8508 20.3464 20.9703 20.0935 20.9944C19.8406 21.0185 19.588 20.9454 19.387 20.79L19.293 20.707L14.548 15.964C13.601 16.6861 12.4956 17.1723 11.3234 17.3824C10.1512 17.5925 8.9458 17.5204 7.80697 17.1721C6.66814 16.8238 5.62862 16.2094 4.77443 15.3795C3.92023 14.5497 3.27592 13.5285 2.8948 12.4002C2.51368 11.2719 2.40672 10.0691 2.58277 8.89131C2.75881 7.7135 3.2128 6.59454 3.90717 5.62703C4.60153 4.65951 5.51631 3.87126 6.57581 3.32749C7.63532 2.78372 8.80908 2.50006 9.99997 2.5V2.5ZM9.99997 4.5C8.54128 4.5 7.14233 5.07946 6.11088 6.11091C5.07943 7.14236 4.49997 8.54131 4.49997 10C4.49997 11.4587 5.07943 12.8576 6.11088 13.8891C7.14233 14.9205 8.54128 15.5 9.99997 15.5C11.4587 15.5 12.8576 14.9205 13.8891 13.8891C14.9205 12.8576 15.5 11.4587 15.5 10C15.5 8.54131 14.9205 7.14236 13.8891 6.11091C12.8576 5.07946 11.4587 4.5 9.99997 4.5Z"" fill=""white""/>");
                sb.AppendLine($@"</svg>");
                sb.AppendLine($@"</button>");
                sb.AppendLine($@"</div>");
                sb.AppendLine($@"</form>");
            }

            sb.AppendLine($@"<div class=""nrow fb-toolbar"">");
            if(showSearch)
            {
                sb.AppendLine($@"<button onclick=""window.location.href='FBback';"" class=""nitem btn btn-primary""");
            }
            else
            {
                sb.AppendLine($@"<button onclick=""goBack();"" class=""nitem btn btn-primary""");
            }
            sb.AppendLine($@"style=""flex-grow: 1; margin-right: 4px;"">");
            sb.AppendLine($@"<svg width=""24"" height=""24"" viewBox=""0 0 24 24"" xmlns=""http://www.w3.org/2000/svg"">");
            sb.AppendLine($@"<path d=""M10.295 19.715C10.4848 19.8963 10.7383 19.9957 11.0007 19.9917C11.2632 19.9878 11.5135 19.8809 11.6978 19.694C11.8821 19.5071 11.9855 19.2552 11.9857 18.9927C11.9859 18.7303 11.883 18.4782 11.699 18.291L6.32902 12.999H19.999C20.2642 12.999 20.5186 12.8937 20.7061 12.7061C20.8937 12.5186 20.999 12.2642 20.999 11.999C20.999 11.7338 20.8937 11.4794 20.7061 11.2919C20.5186 11.1044 20.2642 10.999 19.999 10.999H6.33602L11.7 5.71401C11.884 5.52679 11.9869 5.27475 11.9867 5.01229C11.9865 4.74982 11.8831 4.49796 11.6988 4.31106C11.5145 4.12416 11.2642 4.01721 11.0017 4.01327C10.7393 4.00933 10.4858 4.10872 10.296 4.29001L3.37002 11.112C3.2521 11.2283 3.15847 11.3669 3.09456 11.5196C3.03065 11.6724 2.99774 11.8364 2.99774 12.002C2.99774 12.1676 3.03065 12.3316 3.09456 12.4844C3.15847 12.6372 3.2521 12.7757 3.37002 12.892L10.294 19.715H10.295Z""/>");
            sb.AppendLine($@"</svg>");
            sb.AppendLine($@"</button>");
            sb.AppendLine($@"<button onclick=""window.location.href='FBhome';"" class=""nitem btn btn-primary"" style=""flex-grow: 1; margin-right: 4px;"">");
            sb.AppendLine($@"<svg width=""24"" height=""24"" viewBox=""0 0 24 24"" xmlns=""http://www.w3.org/2000/svg"">");
            sb.AppendLine($@"<path d=""M10.55 2.53301C10.9558 2.19104 11.4693 2.00348 12 2.00348C12.5307 2.00348 13.0442 2.19104 13.45 2.53301L20.2 8.22801C20.708 8.65501 21 9.28401 21 9.94801V19.75C21 20.2141 20.8156 20.6593 20.4874 20.9874C20.1592 21.3156 19.7141 21.5 19.25 21.5H16.25C15.7859 21.5 15.3408 21.3156 15.0126 20.9874C14.6844 20.6593 14.5 20.2141 14.5 19.75V14.75C14.5 14.5511 14.421 14.3603 14.2803 14.2197C14.1397 14.079 13.9489 14 13.75 14H10.25C10.0511 14 9.86032 14.079 9.71967 14.2197C9.57902 14.3603 9.5 14.5511 9.5 14.75V19.75C9.5 20.2141 9.31563 20.6593 8.98744 20.9874C8.65925 21.3156 8.21413 21.5 7.75 21.5H4.75C4.52019 21.5 4.29262 21.4547 4.0803 21.3668C3.86798 21.2789 3.67507 21.15 3.51256 20.9874C3.35006 20.8249 3.22116 20.632 3.13321 20.4197C3.04527 20.2074 3 19.9798 3 19.75V9.94701C3 9.28401 3.292 8.65501 3.8 8.22701L10.55 2.53301V2.53301Z""/>");
            sb.AppendLine($@"</svg>");
            sb.AppendLine($@"</button>");

            if (showSearch)
            {
                sb.AppendLine($@"<div class=""input-group nitem sort-field"">");
                sb.AppendLine($@"<div class=""input-group-prepend"">");
                sb.AppendLine($@"<label class=""input-group-text"" for=""inputGroupSelect01"">Sort by:</label>");
                sb.AppendLine($@"</div>");
                sb.AppendLine($@"<select onchange=""sort('{Base64Encode(currentPath)}')"" class=""custom-select"" id=""inputGroupSelect01"">");
                sb.AppendLine($@"<option {nameASC} value=""1"">Name ↑</option>");
                sb.AppendLine($@"<option {nameDESC} value=""2"">Name ↓</option>");
                sb.AppendLine($@"<option {dateASC} value=""3"">Date ↑</option>");
                sb.AppendLine($@"<option {dateDESC} value=""4"">Date ↓</option>");
                sb.AppendLine($@"</select>");
                sb.AppendLine($@"</div>");
            }
            sb.AppendLine($@"</div>");

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