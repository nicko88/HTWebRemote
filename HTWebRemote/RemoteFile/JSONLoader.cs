using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace HTWebRemote.RemoteFile
{
    class JSONLoader
    {
        public static Remote LoadRemoteJSON(string remoteID)
        {
            Remote remote = new Remote();
            try
            {
                string json = File.ReadAllText($"{Util.ConfigHelper.jsonButtonFiles}{remoteID}.json");
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

                File.WriteAllText($"{Util.ConfigHelper.jsonButtonFiles}{remote.RemoteID}.json", json);
            }
            catch { }
        }

        public static List<HotKey> LoadHotkeyJSON()
        {
            List<HotKey> hotKeys = new List<HotKey>();
            try
            {
                string json = File.ReadAllText(Path.Combine(Util.ConfigHelper.WorkingPath, "HTWebRemoteHotKeys.json"));
                hotKeys = JsonConvert.DeserializeObject<List<HotKey>>(json);
            }
            catch { }

            return hotKeys;
        }

        public static void SaveHotkeyJSON(List<HotKey> hotKeys)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;

                string json = JsonConvert.SerializeObject(hotKeys, Formatting.Indented, settings);

                File.WriteAllText(Path.Combine(Util.ConfigHelper.WorkingPath, "HTWebRemoteHotKeys.json"), json);
            }
            catch { }
        }
    }
}