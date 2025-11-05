using System.ComponentModel.DataAnnotations;

namespace BookBrain.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, Display(Name = "Име")]
        public string FirstName { get; set; } = string.Empty;

        [Required, Display(Name = "Фамилия")]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress, Display(Name = "Имейл")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Дата на регистрация")]
        public DateTime RegisteredAt { get; set; } = DateTime.Now;
    }
}
