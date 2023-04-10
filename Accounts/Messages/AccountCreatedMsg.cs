using System.Reflection.Metadata.Ecma335;

namespace Accounts.Messages
{
    public record AccountCreatedMsg (
        long AccountId,
        string AccountNumber,
        string CustomerId
    );
}
