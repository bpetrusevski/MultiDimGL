namespace Accounts.RabbitMQ
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message,string routingKey);
    }
}
