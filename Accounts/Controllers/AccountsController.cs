
using Microsoft.AspNetCore.Mvc;
using Accounts.Database;
using Accounts.Models.Commands;
using Microsoft.Extensions.Logging;
using System.Threading;
using Accounts.Messages;
using Infrastructure.RabbitMQ;

namespace Accounts.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IMessageProducer _messagePublisher;
        private readonly ILogger<AccountsController> _logger;
        private readonly AccountsDbContext _dbContext;

        public AccountsController(ILogger<AccountsController> logger, IMessageProducer messagePublisher, AccountsDbContext dbContext)
        {
            _logger = logger;
            _messagePublisher = messagePublisher;
            _dbContext = dbContext;
        }

        [HttpPost(Name = "create-account")]
        public async Task<IActionResult> CreateAccount([FromBody]CreateAccountCommandBody newAccount)
        {
            AccountArrangement acc = new CurrentAccount();
            Random rgen = new Random();
            
            acc.DateCreated = DateTime.UtcNow;
            acc.AccountNumber = rgen.NextInt64(9999999999999999).ToString().PadLeft(16, '0');
            acc.Balance = 0;
            acc.CustomerID = newAccount.CustomerID;
            _dbContext.Accounts.Add(acc);

            var @messsage = new AccountCreatedMsg(acc.AccountId, acc.AccountNumber, acc.CustomerID);

            await SaveChangesAndPublish(@messsage, @messsage.AccountNumber,  HttpContext.RequestAborted);
            
            return Ok(acc.AccountNumber);
            
        }

        // TO DO, implement outbox pattern
        private async Task SaveChangesAndPublish(object @messsage, string routingKey, CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);

            _messagePublisher.SendMessage(@messsage, routingKey);
        }
    }
}