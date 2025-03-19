using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public required string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public bool Fixed { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
