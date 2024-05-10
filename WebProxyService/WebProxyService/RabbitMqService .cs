using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebProxyService
{
    class RabbitMqService : IRabbitMqService
	{
		public void SendMessage(object obj)
		{
			var message = JsonSerializer.Serialize(obj);
			SendMessage(message);
		}

		public void SendMessage(string message)
		{
			Settings settings = new Settings();
			var factory = new ConnectionFactory() { HostName = settings.rabbitHots };
			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare(queue: "Logs",
							   durable: false,
							   exclusive: false,
							   autoDelete: false,
							   arguments: null);

				var body = Encoding.UTF8.GetBytes(message);

				channel.BasicPublish(exchange: "",
							   routingKey: "Logs",
							   basicProperties: null,
							   body: body);
			}
		}
	}
}
