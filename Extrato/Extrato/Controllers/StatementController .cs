using Extrato.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Extrato.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatementController : Controller
    {

        private readonly ITransactionService _transactionService;

        public StatementController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("{days}")]
        public IActionResult GetStatement(int days)
        {
            var transactions = _transactionService.GetTransactions(days);
            return Ok(transactions);
        }

        
    }
}
