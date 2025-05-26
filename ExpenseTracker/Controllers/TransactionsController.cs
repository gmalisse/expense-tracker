using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransactionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> Get()
        {
            try
            {
                var transactions = _context.Transactions.ToList();
                return transactions;
            }
            catch (Exception)
            {
                return NotFound("No transactions found.");
            }
        }

        [HttpPost]
        public ActionResult<Transaction> Post(Transaction transaction)
        {
            try
            {
                _context.Transactions.Add(transaction);
                _context.SaveChanges();
                return CreatedAtAction(nameof(Get), new { id = transaction.Id }, transaction);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating category.");
            }
        }
    }
}
