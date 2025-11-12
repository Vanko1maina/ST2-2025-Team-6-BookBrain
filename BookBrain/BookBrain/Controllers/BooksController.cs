using BookBrain.Models;
using BookBrain.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookBrain.Controllers
{
    public class BooksController : Controller
    {
        private readonly IRepository<Book> _repo;

        public BooksController(IRepository<Book> repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _repo.GetAllAsync();
            return View(books);
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _repo.GetByIdAsync(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                await _repo.AddAsync(book);
                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _repo.GetByIdAsync(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _repo.UpdateAsync(book);
                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _repo.GetByIdAsync(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
