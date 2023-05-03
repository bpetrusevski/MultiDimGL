
using Azure;
using MDGeneralLedger.Commands;
using MDGeneralLedger.Database;
using MDGeneralLedger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;

namespace PositionKeeping.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeneralLedgerController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly GeneralLedgerDB _db;
        private readonly Metamodel _model;

        public GeneralLedgerController(ILogger<GeneralLedgerController> logger, GeneralLedgerDB database, Metamodel model)
        {
            _logger = logger;
            _db = database;
            _model = model;

            
            //database.AcctDim.AsNoTracking().ForEachAsync(x => { _model.AcctDim.Add(x); });
        }

        [HttpGet("Accounts")]
        public async Task<ActionResult> GetChartOfAccounts()
        {
            try
            {
                var res = _db.Accounts.AsNoTracking().ToList();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("Accounts")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand cmd)
        {
            try
            {
                var acct = new GlAccount(); 
                var record = await _db.Accounts.AddAsync(acct);

                await _db.SaveChangesAsync();

                return Ok(record.Entity.Account);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AccountDim")]
        public async Task<IActionResult> CreateDimension([FromBody] ClassificationSchema cmd)
        {
            try
            {
                //_db.EnableServiceProviderCaching = true;
                _model.AcctDim.Add(cmd);
                _db.AcctDim.AddAsync(cmd);
                await _db.SaveChangesAsync();

                //_dims.AcctDim.Add(cmd);

                //_db.Database.Migrate();


                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}