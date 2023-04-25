using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace Infrastructure.RabbitMQ
{
    public class RabbitMQProducer : IMessageProducer
    {
        private readonly RabbitMQClientConfiguration config;
        private readonly IConnection connection;

        public RabbitMQProducer(
            IConfiguration configuration
        )
        {
            // get configuration from appsettings.json
            config = configuration.GetRabbitMQClientConfig();

            var factory = new ConnectionFactory()
            {
                HostName = config.HostName,
                UserName = config.UserName,
                Password = config.Password
            };

            connection = factory.CreateConnection(config.ClientName);

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "accounts",
                                      autoDelete: false,
                                      durable: false,
                                      exclusive: false);

                channel.QueueDeclare(queue: "PositionKeeping",
                                      autoDelete: false,
                                      durable: false,
                                      exclusive: false);
            }

        }

        public void SendMessage(object message, string routingKey)
        {

            using (var channel = connection.CreateModel())
            {
                /*
                channel.ConfirmSelect();

                channel.BasicAcks += (sender, eventArgs) =>
                    {
                        //implement ack handle
                    };

                channel.BasicNacks += (sender, eventArgs) =>
                {
                    //implement ack handle
                };
                */


                var properties = channel.CreateBasicProperties();
                properties.MessageId = Guid.NewGuid().ToString();
                properties.Type = message.GetType().Name;


                var json = JsonSerializer.Serialize(message);
                var body = Encoding.UTF8.GetBytes(json);


                channel.BasicPublish(exchange: string.Empty, routingKey: routingKey, basicProperties: properties, body: body);

                //channel.WaitForConfirmsOrDie();
            }

        }
    }
}
