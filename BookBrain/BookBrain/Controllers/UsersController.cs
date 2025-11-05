using BookBrain.Models;
using BookBrain.Data;
using Microsoft.AspNetCore.Mvc;
using BookBrain.Services.Repositories;

namespace BookBrain.Controllers
{
    public class UsersController : Controller
    {
        private readonly IRepository<User> _repo;
        public UsersController(IRepository<User> repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _repo.GetAllAsync();
            return View(users);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await _repo.AddAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            return user == null ? NotFound() : View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if (ModelState.IsValid)
            {
                await _repo.UpdateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
