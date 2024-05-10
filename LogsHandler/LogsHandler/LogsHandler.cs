using Nest;
using Elasticsearch.Net;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using Meilisearch;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Text.Json;
using MongoDB.Bson;
using System.Collections.Generic;

namespace LogsHandler
{
    class LogsHandler
    {
        static async Task Main(string[] args)
        {
			Console.WriteLine("LogsHandler");
			List<string> logs = new List<string>();
			MongoDDUtils mongo = new MongoDDUtils();
			var factory = new ConnectionFactory() { HostName = mongo.settings.rabbitHots};
			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare(queue: "Logs",
									 durable: false,
									 exclusive: false,
									 autoDelete: false,
									 arguments: null);

				var consumer = new EventingBasicConsumer(channel);
				consumer.Received += (model, ea) =>
				{
					var body = ea.Body.ToArray();
					var message = Encoding.UTF8.GetString(body);
					if(logs.Count > 50)
                    {
						addLogs(mongo, logs);
						logs.Clear();
					}
					logs.Add(message);
				};
				channel.BasicConsume(queue: "Logs",
									 autoAck: true,
									 consumer: consumer);

				Console.ReadLine();
			}
		}

		public static async Task addLogs(MongoDDUtils mongo, List<string> logs)
        {
			List<BsonDocument> bsonLogs = new List<BsonDocument>();
			foreach(string log in logs)
            {
				bsonLogs.Add(BsonDocument.Parse(log));
			}
			await mongo.logs.InsertManyAsync(bsonLogs);

		}
    }
}
