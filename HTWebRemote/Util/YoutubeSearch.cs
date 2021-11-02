using System;
using System.IO;
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
            page.Append(header);
            page.Append(GetHTMLRemoteTabs());
            page.Append(@"<button onclick=""closetab()"" class=""btn btn-primary"">Close YouTube Tab</button>");

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
                            sb.AppendLine($@"<a class=""nav-link text-muted"" href=""{remoteNum}"">{remoteName}</a>");
                            sb.AppendLine("</li>");
                        }
                    }

                    sb.AppendLine($@"<li class=""nav-item""><a class=""nav-link text-muted"" href=""FB"">FB</a></li>");
                    sb.AppendLine($@"<li class=""nav-item""><a class=""nav-link bg-dark active text-white"" href=""FByoutube?play=0"">YT</a></li>");

                    sb.AppendLine("</ul>");
                }
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