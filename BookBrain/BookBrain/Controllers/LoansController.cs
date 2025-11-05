using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BookBrain.Models;
using BookBrain.Services.Repositories;

namespace BookBrain.Web.Controllers
{
    public class LoansController : Controller
    {
        private readonly IRepository<Loan> _repo;
        public LoansController(IRepository<Loan> repo) => _repo = repo;

        public async Task<IActionResult> Index() => View(await _repo.GetAllAsync());
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Loan loan)
        {
            await _repo.AddAsync(loan);
            return RedirectToAction(nameof(Index));
        }
    }
}
