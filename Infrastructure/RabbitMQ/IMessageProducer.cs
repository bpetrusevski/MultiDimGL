namespace Infrastructure.RabbitMQ
{
    public interface IMessageProducer
    {
        void SendMessage(object message,string routingKey);
    }
}
