using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryTypesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryTypesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryType>> Get()
        {
            try
            {
                var categoryTypes = _context.CategoryTypes.ToList();
                return categoryTypes;
            }
            catch(Exception)
            {
                return NotFound("There are no category types.");
            }
            
        }

        [HttpGet("{id:int}")]
        public ActionResult<CategoryType> Get(int id)
        {
            try
            {
                var categoryType = _context.CategoryTypes.
                    SingleOrDefault(c => c.Id == id);
                return categoryType;
            }
            catch (Exception)
            {
                return NotFound("Category type not found.");
            }
        }
    }
}
