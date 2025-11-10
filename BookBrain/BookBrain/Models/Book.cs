using System.ComponentModel.DataAnnotations;

namespace BookBrain.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required, Display(Name = "Заглавие")]
        public string Title { get; set; } = string.Empty;

        [Required, Display(Name = "Автор")]
        public string Author { get; set; } = string.Empty;

        [Required, Display(Name = "Жанр")]
        public string Genre { get; set; } = string.Empty;

        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
    }
}
