using System.Collections.Generic;

namespace HTPCRemote.RemoteFile
{
    class Remote
    {
        public int RemoteID { get; set; }
        public string RemoteName { get; set; }
        public int ButtonHeight { get; set; }
        public string RemoteBackColor { get; set; }
        public string RemoteTextColor { get; set; }
        public List<RemoteItem> RemoteItems { get; set; }

        public Remote() { }
        public Remote(int remoteID)
        {
            RemoteID = remoteID;
            RemoteItems = new List<RemoteItem>();
        }
    }
}