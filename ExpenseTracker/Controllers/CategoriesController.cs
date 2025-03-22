using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            try
            {
                var categories = _context.Categories.ToList();
                return categories;
            }
            catch (Exception)
            {
                return NotFound("There are no categories.");
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<Category> Get(int id)
        {
            try
            {
                var category = _context.Categories.
                    SingleOrDefault(c => c.Id == id);
                return category;
            }
            catch (Exception)
            {
                return NotFound("Category not found.");
            }
        }

        [HttpPost]
        public ActionResult<Category> Post(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating category.");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Category category)
        {
            try
            {   
                if (id != category.Id)
                {
                    return BadRequest("Id's do not match");
                }
                _context.Entry(category).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest($"It was not possible to update the category of id {id}.");
            }            
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                var category = _context.Categories.
                    SingleOrDefault(p => p.Id == id);
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return Ok(category);
            }
            catch (Exception)
            {
                return NotFound("Category not found.");
            }
        }

    }
}
