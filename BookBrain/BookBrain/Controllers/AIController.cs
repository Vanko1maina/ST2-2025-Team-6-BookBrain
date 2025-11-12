using BookBrain.Services;
using BookBrain.Services.Adapters;
using Microsoft.AspNetCore.Mvc;

namespace BookBrain.Controllers
{
    public class AIController : Controller
    {
        private readonly AIService _aiService;

        public AIController()
        {
            var adapter = new GPT4AllAdapter();
            _aiService = AIService.GetInstance(adapter);
        }

        [HttpPost]
        public async Task<IActionResult> Summarize(string description)
        {
            var summary = await _aiService.SummarizeBookAsync(description);
            ViewBag.Summary = summary;
            return View("Result");
        }
    }
}
