using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class CategoryType
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }
        public ICollection<Category> Categories { get; set; }

        public CategoryType()
        {
            Categories = new Collection<Category>();
        }
    }
}
