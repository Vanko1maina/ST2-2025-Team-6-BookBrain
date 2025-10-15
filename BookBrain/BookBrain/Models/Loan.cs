﻿namespace BookBrain.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime LoanDate { get; set; } = DateTime.Now;
        public DateTime? ReturnDate { get; set; }

        public Book? Book { get; set; }
        public User? User { get; set; }
    }
}
