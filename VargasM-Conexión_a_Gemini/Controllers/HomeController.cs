using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VargasM_Conexión_a_Gemini.Models;
using VargasM_Conexión_a_Gemini.Repositories;

namespace VargasM_Conexión_a_Gemini.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            GeminiRepository repo = new GeminiRepository();
            string answer = await repo.GetChatbotResponse("¿Cuáles son los beneficios de la inteligencia artificial?");

            return View(answer);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
