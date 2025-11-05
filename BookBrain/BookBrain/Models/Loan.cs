using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookBrain.Models
{
    public class Loan
    {
        public int Id { get; set; }

        [Required, Display(Name = "Книга")]
        public int BookId { get; set; }

        [Required, Display(Name = "Потребител")]
        public int UserId { get; set; }

        [Display(Name = "Дата на заемане")]
        public DateTime LoanDate { get; set; } = DateTime.Now;

        [Display(Name = "Дата на връщане")]
        public DateTime? ReturnDate { get; set; }

        [ForeignKey("BookId")]
        public Book? Book { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
