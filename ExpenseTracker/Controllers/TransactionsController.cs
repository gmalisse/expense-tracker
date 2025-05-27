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

        [HttpGet("{id:int}")]
        public ActionResult<Transaction> Get(int id)
        {
            try
            {
                var transaction = _context.Transactions.
                    SingleOrDefault(c => c.Id == id);
                return transaction;
            }
            catch (Exception)
            {
                return NotFound("Transaction not found.");
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating transaction.");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Transaction transaction)
        {
            try
            {
                if (id != transaction.Id)
                {
                    return BadRequest("Id's do not match");
                }
                _context.Entry(transaction).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest($"It was not possible to update the transaction of id {id}.");
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                var transaction = _context.Transactions.
                    SingleOrDefault(p => p.Id == id);
                _context.Transactions.Remove(transaction);
                _context.SaveChanges();
                return Ok(transaction);
            }
            catch (Exception)
            {
                return NotFound("Transaction not found.");
            }
        }
    }
}
