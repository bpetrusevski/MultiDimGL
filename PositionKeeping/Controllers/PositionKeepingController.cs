using Infrastructure.RabbitMQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PositionKeeping.Database;
using PositionKeeping.Events;
using PositionKeeping.Models;
using System.Threading;

namespace PositionKeeping.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionKeepingController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly PositionKeepingDB _database;
        private readonly IMessageProducer _messageProducer;

        public PositionKeepingController(ILogger<PositionKeepingController> logger, PositionKeepingDB database, IMessageProducer messageProducer)
        {
            _logger = logger;
            _database = database;
            _messageProducer = messageProducer;
        }

        [HttpGet("ClassificationSchema")]
        public async Task<ActionResult> GetClassificationSchemas()
        {
            try
            {
                return Ok(_database.ClassificationSchemas.AsNoTracking().ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("ClassificationSchema")]
        public async Task<IActionResult> PostClassificationSchema([FromBody] ClassificationSchema schema)
        {
            try
            {
                var record = await _database.ClassificationSchemas.AddAsync(schema);

                await _database.SaveChangesAsync();

                /*
                //should implement OutBox pattern
                var msg = new ClassificationSchemaAdded(record.Entity.Id, schema.Code, schema.Name);

                await SaveChangesAndPublish(msg, msg.SchemaCode, HttpContext.RequestAborted);
                */
                return Ok(record.Entity.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("AccountUnit")]
        public async Task<IActionResult> CreateAccountUnit([FromBody] AccountUnit NewAccountUnitCommand)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Not implmented");

        }


        // TO DO, implement outbox pattern
        private async Task SaveChangesAndPublish<TMessage>(TMessage @messsage, string routingKey, CancellationToken cancellationToken) where TMessage : notnull
        {
            await _database.SaveChangesAsync(cancellationToken);

            _messageProducer.SendMessage(@messsage, routingKey);
        }

    }
}