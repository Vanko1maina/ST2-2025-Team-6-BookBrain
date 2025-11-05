using BookBrain.Models;
using BookBrain.Services.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookBrain.Data.Repositories
{
    public class LoanRepository : IRepository<Loan>
    {
        private readonly AppDbContext _context;
        public LoanRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Loan>> GetAllAsync()
            => await _context.Loans.Include(l => l.Book).Include(l => l.User).ToListAsync();

        public async Task<Loan?> GetByIdAsync(int id)
            => await _context.Loans.Include(l => l.Book).Include(l => l.User)
                                   .FirstOrDefaultAsync(l => l.Id == id);

        public async Task AddAsync(Loan loan)
        {
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Loan loan)
        {
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan != null)
            {
                _context.Loans.Remove(loan);
                await _context.SaveChangesAsync();
            }
        }
    }
}
