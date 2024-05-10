using Newtonsoft.Json.Linq;
using Npgsql;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpeechHandler
{
    class SpeechHandler
    {
		static async Task Main(string[] args)
		{
			Console.WriteLine("SpeechHandler");

			List<string> logs = new List<string>();
			Settings settings = new Settings();
			var factory = new ConnectionFactory() { HostName = settings.rabbitHots };
			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare(queue: "words",
									 durable: false,
									 exclusive: false,
									 autoDelete: false,
									 arguments: null);

				var consumer = new EventingBasicConsumer(channel);
				consumer.Received += (model, ea) =>
				{
					var body = ea.Body.ToArray();
					var message = Encoding.UTF8.GetString(body);
					Console.WriteLine(message);
					addLogs(message);
				};
				channel.BasicConsume(queue: "words",
									 autoAck: true,
									 consumer: consumer);

				Console.ReadLine();
			}
		}

		public static void addLogs(string message)
		{
            JObject json = JObject.Parse(message);
            NpgsqlConnection connection = DBUtils.GetDBConnection();

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.Parameters.AddWithValue((int)json["userId"]);
            cmd.Parameters.AddWithValue((string)json["message"]);
            cmd.Parameters.AddWithValue((DateTime)json["date"]);

            cmd.CommandText = "INSERT INTO StopWordsLogs(userId, message, date) VALUES($1, $2, $3);";
            try
            {
				cmd.ExecuteScalar();
            }
            catch (InvalidOperationException exp)
            {
                Console.WriteLine($"{exp.Message}");
            }
			connection.Close();
		}
	}
}
