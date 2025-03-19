using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public required string Name { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }
        public int CategoryTypeId { get; set; }
        public CategoryType CategoryType { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

        public Category()
        {
            Transactions = new Collection<Transaction>();
        }
    }
}
