using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsHandler
{
    public class MongoDDUtils
    {
        public MongoClient client;
        public IMongoDatabase db;
        public IMongoCollection<BsonDocument> logs;
        public Settings settings;

        public MongoDDUtils()
        {
            settings = new Settings();
            client = new MongoClient(settings.mongoHost);
            db = client.GetDatabase(settings.mongoDb);
            logs = db.GetCollection<BsonDocument>("Logs");
        }
    }
}
