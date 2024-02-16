using System;
using System.IO;
using System.Linq;
using System.Text;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json.Linq;

namespace HTWebRemote.Util
{
    class YoutubeSearch
    {
        private static readonly string YoutubeAPIKey = "";

        public static string _searchQ;
        private static (SearchListResponse, string) _result;
        public static string LoadSearchResults(string searchQ)
        {
            StringBuilder page = new StringBuilder();

            string header = ConfigHelper.GetEmbeddedResource("youtubeSearchHeader.html");

            if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "BottomTabs"))
            {
                header = header.Replace("flex-direction: column;", "flex-direction: column-reverse;");
                header = header.Replace("justify-content: flex-start;", "justify-content: space-between;");
            }

            page.Append(header);
            page.Append(GetHTMLRemoteTabs());
            page.AppendLine(@"<div class=""container body-content"">");
            page.AppendLine(@"<button onclick=""closetab()"" class=""btn"" style=""background-color: #424548; color: #FFFFFF;"">Close YouTube Tab</button>");

            page.AppendLine(@"<form method=""POST"" id=""youtubeform"" action=""FByoutube"">");
            page.AppendLine(@"<input type=""hidden"" id=""youtube"" name=""youtube"" value="""">");
            page.AppendLine("</form>");

            if (_searchQ != searchQ)
            {
                _searchQ = searchQ;
                _result = Search(searchQ);
            }

            SearchListResponse searchListResponse = _result.Item1;

            if (_result.Item2 == null)
            {
                foreach (SearchResult searchResult in searchListResponse.Items)
                {
                    if (searchResult.Id.Kind == "youtube#video")
                    {
                        page.Append($@"<div class=""video"" onclick=""play('{searchResult.Id.VideoId}')"">");
                        page.Append($@"<div><img src=""https://i.ytimg.com/vi/{searchResult.Id.VideoId}/mqdefault.jpg"" width=""160"" height=""90""></div>");
                        page.Append(@"<div class=""text"">");
                        page.Append($@"<span>{searchResult.Snippet.Title}</span>");
                        page.Append($@"<span style=""color: grey;"">{searchResult.Snippet.ChannelTitle}</span>");
                        page.Append("</div>");
                        page.Append("</div>");
                    }
                }
            }
            else
            {
                if(_result.Item2.Contains("API key"))
                {
                    page.Append("<br />");
                    page.Append(@"Please check your Youtube API Key in the ""Edit File Browser"" settings screen as it appears to be missing or incorrect.");
                    page.Append("<br /><br />");
                }
                else if(_result.Item2.Contains("quota"))
                {
                    page.Append("<br />");
                    page.Append(@"The built-in YouTube search limit has been reached for today.  If you want to remove this limit please create and enter your own YouTube API Key into the ""Edit File Browser"" settings screen.");
                    page.Append("<br /><br />");
                }

                page.Append("Error:");
                page.Append("<br />");
                page.Append(_result.Item2);
            }

            page.Append("</div></body></html>");
            return page.ToString();
        }

        private static (SearchListResponse, string) Search(string searchQ)
        {
            BaseClientService.Initializer initializer = new BaseClientService.Initializer();
            initializer.ApiKey = GetAPIKey();
            YouTubeService youtubeService = new YouTubeService(initializer);

            SearchResource.ListRequest searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = searchQ;
            searchListRequest.MaxResults = 50;

            SearchListResponse searchListResponse = new SearchListResponse();

            string error = null;
            try
            {
                searchListResponse = searchListRequest.Execute();
            }
            catch (Exception e)
            {
                error = e.Message;
            }

            return (searchListResponse, error);
        }

        public static string GetHTMLRemoteTabs()
        {
            string fileBrowserGroup = ConfigHelper.GetRegKey(@"SOFTWARE\HTWebRemote", "FileBrowserGroup");

            StringBuilder sb = new StringBuilder();

            try
            {
                string[] remoteFiles = Directory.GetFiles(ConfigHelper.WorkingPath, "HTWebRemoteButtons*").CustomSort().ToArray();

                sb.AppendLine(@"<div class=""nav-container"">");
                sb.AppendLine(@"<ul class=""nav nav-tabs sticky-top"">");

                if (ConfigHelper.CheckRegKey(@"SOFTWARE\HTWebRemote", "GroupListButton"))
                {
                    sb.AppendLine($@"<li class=""nav-item"" style=""display: contents;""><a class=""nav-link"" href=""/"">");
                    sb.AppendLine($@"<svg width=""24"" height=""24"" viewBox=""0 0 16 16"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">");
                    sb.AppendLine($@"<path d=""M8.707 1.5a1 1 0 0 0-1.414 0L.646 8.146a.5.5 0 0 0 .708.708L2 8.207V13.5A1.5 1.5 0 0 0 3.5 15h9a1.5 1.5 0 0 0 1.5-1.5V8.207l.646.647a.5.5 0 0 0 .708-.708L13 5.793V2.5a.5.5 0 0 0-.5-.5h-1a.5.5 0 0 0-.5.5v1.293zM13 7.207V13.5a.5.5 0 0 1-.5.5h-9a.5.5 0 0 1-.5-.5V7.207l5-5z"" fill=""white"" />");
                    sb.AppendLine("</svg></a></li>");
                }

                foreach (string file in remoteFiles)
                {
                    if (file.Contains(".json"))
                    {
                        JObject oRemote = JObject.Parse(File.ReadAllText(file));

                        string remoteNum = (string)oRemote.SelectToken("RemoteID");
                        string remoteName = (string)oRemote.SelectToken("RemoteName");
                        string remoteGroup = (string)oRemote.SelectToken("RemoteGroup");

                        bool hideRemote = false;
                        try
                        {
                            hideRemote = (bool)oRemote.SelectToken("HideRemote");
                        }
                        catch { }

                        if (fileBrowserGroup != remoteGroup)
                        {
                            hideRemote = true;
                        }

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

                sb.AppendLine($@"<li class=""nav-item""><a class=""nav-link"" href=""FB"">");
                sb.AppendLine($@"<svg width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">");
                sb.AppendLine($@"<path d=""M16.5 12C19 12 21 14 21 16.5C21 17.38 20.75 18.21 20.31 18.9L23.39 22L22 23.39L18.88 20.32C18.19 20.75 17.37 21 16.5 21C14 21 12 19 12 16.5C12 14 14 12 16.5 12ZM16.5 14C15.837 14 15.2011 14.2634 14.7322 14.7322C14.2634 15.2011 14 15.837 14 16.5C14 17.163 14.2634 17.7989 14.7322 18.2678C15.2011 18.7366 15.837 19 16.5 19C17.163 19 17.7989 18.7366 18.2678 18.2678C18.7366 17.7989 19 17.163 19 16.5C19 15.837 18.7366 15.2011 18.2678 14.7322C17.7989 14.2634 17.163 14 16.5 14ZM9 4L11 6H19C19.5304 6 20.0391 6.21071 20.4142 6.58579C20.7893 6.96086 21 7.46957 21 8V11.81C19.7909 10.6469 18.1778 9.99803 16.5 10C14.7761 10 13.1228 10.6848 11.9038 11.9038C10.6848 13.1228 10 14.7761 10 16.5C10 17.79 10.37 19 11 20H3C2.46957 20 1.96086 19.7893 1.58579 19.4142C1.21071 19.0391 1 18.5304 1 18V6C1 4.89 1.89 4 3 4H9Z"" fill=""white"" />");
                sb.AppendLine("</svg></a></li>");

                sb.AppendLine($@"<li class=""nav-item""><a class=""nav-link active"" href=""FByoutube?play=0"">");
                sb.AppendLine($@"<svg width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">");
                sb.AppendLine($@"<path d=""M19.615 3.184c-3.604-.246-11.631-.245-15.23 0-3.897.266-4.356 2.62-4.385 8.816.029 6.185.484 8.549 4.385 8.816 3.6.245 11.626.246 15.23 0 3.897-.266 4.356-2.62 4.385-8.816-.029-6.185-.484-8.549-4.385-8.816zm-10.615 12.816v-8l8 3.993-8 4.007z"" fill=""white"" />");
                sb.AppendLine("</svg></a></li>");

                sb.AppendLine("</ul>");
                sb.AppendLine("</div>");
                sb.AppendLine();
            }
            catch { }

            return sb.ToString();
        }

        private static string GetAPIKey()
        {
            string APIKey = ConfigHelper.GetRegKey(@"SOFTWARE\HTWebRemote", "YoutubeAPIKey");

            if(string.IsNullOrEmpty(APIKey))
            {
                APIKey = YoutubeAPIKey;
            }

            return APIKey; 
        }
    }
}