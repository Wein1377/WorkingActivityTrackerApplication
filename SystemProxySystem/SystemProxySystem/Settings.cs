using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemProxySystem
{
    public class Settings
    {
        public string dbHost { get; set; }
        public string dbUser { get; set; }
        public string dbPassword { get; set; }
        public string db { get; set; }
        public int dbPort { get; set; }
        public int userId { get; set; }
        public string rabbitHots { get; set; }
        public string mongoHost { get; set; }
        public string mongoDb { get; set; }

        public Settings()
        {
            JObject data = JObject.Parse(File.ReadAllText(@"C:\Users\Nikita\Desktop\Диплом\ClientService\conf.json"));
            this.dbHost = data.Value<string>("dbHost");
            this.dbUser = data.Value<string>("dbUser");
            this.dbPassword = data.Value<string>("dbPassword");
            this.db = data.Value<string>("db");
            this.dbPort = data.Value<int>("dbPort");
            this.userId = data.Value<int>("userId");
            this.rabbitHots = data.Value<string>("rabbitHots");
            this.mongoHost = data.Value<string>("mongoHost");
            this.mongoDb = data.Value<string>("mongoDb");
        }

    }
}
