using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BookBrain.Models;
using BookBrain.Services.Repositories;

namespace BookBrain.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IRepository<User> _repo;
        public UsersController(IRepository<User> repo) => _repo = repo;

        public async Task<IActionResult> Index() => View(await _repo.GetAllAsync());
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await _repo.AddAsync(user);
            return RedirectToAction(nameof(Index));
        }
    }
}
