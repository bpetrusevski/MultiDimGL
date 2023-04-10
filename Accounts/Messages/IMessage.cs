using System.Xml.Linq;

namespace Accounts.Messages
{
    public interface IMessage
    {
        Guid Id { get; }
        Guid CorrelationId { get; }
        object MessageBody { get; }
    }
}
