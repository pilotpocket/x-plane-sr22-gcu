using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SR22gcu
{
    public class ConnectionParameters
    {
        public string HostIp { get; set; } = "127.0.0.1";
        public string Port { get; set; } = "49000";

        public const string FileName = "options.json";
        public static ConnectionParameters Load()
        {
            try
            {
                if (File.Exists(FileName))
                    return JsonConvert.DeserializeObject<ConnectionParameters>(File.ReadAllText(FileName));
            }
            catch 
            {
            }
            return new ConnectionParameters();
        }

        public void Save()
        {
            File.WriteAllText(FileName, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}
