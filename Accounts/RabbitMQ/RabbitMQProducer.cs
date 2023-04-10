using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Accounts.RabbitMQ
{
    public class RabbitMQProducer : IMessageProducer
    {
        private readonly RabbitMQClientConfiguration config;

        public RabbitMQProducer(
            IConfiguration configuration
        )
        {
            // get configuration from appsettings.json
            config = configuration.GetRabbitMQClientConfig();
        }

        public void SendMessage<T>(T message, string routingKey)
        {
            var factory = new ConnectionFactory()
            {
                HostName = config.HostName,
                UserName = config.UserName,
                Password = config.Password
            };

            var connection = factory.CreateConnection("Accounts Service");
            using var channel = connection.CreateModel();

            channel.QueueDeclare("accounts", exclusive: false);

            var properties = channel.CreateBasicProperties();
            properties.MessageId = Guid.NewGuid().ToString();
            properties.Type = typeof(T).Name;

            var json = JsonSerializer.Serialize<T>(message);
            var body = Encoding.UTF8.GetBytes(json);


            channel.BasicPublish(exchange: "", routingKey: routingKey, basicProperties: properties,  body: body);
        }
    }
}
