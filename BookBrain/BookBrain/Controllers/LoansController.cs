using BookBrain.Models;
using BookBrain.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookBrain.Services.Repositories;

namespace BookBrain.Controllers
{
    public class LoansController : Controller
    {
        private readonly IRepository<Loan> _loanRepo;
        private readonly IRepository<Book> _bookRepo;
        private readonly IRepository<User> _userRepo;

        public LoansController(IRepository<Loan> loanRepo, IRepository<Book> bookRepo, IRepository<User> userRepo)
        {
            _loanRepo = loanRepo;
            _bookRepo = bookRepo;
            _userRepo = userRepo;
        }

        public async Task<IActionResult> Index()
        {
            var loans = await _loanRepo.GetAllAsync();
            return View(loans);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Books = new SelectList(await _bookRepo.GetAllAsync(), "Id", "Title");
            ViewBag.Users = new SelectList(await _userRepo.GetAllAsync(), "Id", "FirstName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Loan loan)
        {
            if (ModelState.IsValid)
            {
                await _loanRepo.AddAsync(loan);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Books = new SelectList(await _bookRepo.GetAllAsync(), "Id", "Title");
            ViewBag.Users = new SelectList(await _userRepo.GetAllAsync(), "Id", "FirstName");
            return View(loan);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _loanRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ReturnBook(int id)
        {
            var loan = await _loanRepo.GetByIdAsync(id);
            if (loan == null) return NotFound();

            loan.ReturnDate = DateTime.Now;
            await _loanRepo.UpdateAsync(loan);

            return RedirectToAction(nameof(Index));
        }
    }
}
