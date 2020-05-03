using Newtonsoft.Json;
using System.IO;

namespace HTPCRemote.RemoteFile
{
    class RemoteJSONLoader
    {
        public static Remote LoadRemoteJSON(string remoteID)
        {
            Remote remote = new Remote();
            try
            {
                string json = File.ReadAllText(Util.ConfigHelper.jsonButtonFiles + remoteID + ".json");
                remote = JsonConvert.DeserializeObject<Remote>(json);
            }
            catch { }

            return remote;
        }

        public static void SaveRemoteJSON(Remote remote)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;

                string json = JsonConvert.SerializeObject(remote, Formatting.Indented, settings);

                File.WriteAllText(Util.ConfigHelper.jsonButtonFiles + remote.RemoteID + ".json", json);
            }
            catch { }
        }
    }
}