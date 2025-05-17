using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VargasM_Conexión_a_Gemini.Interfaces;
using VargasM_Conexión_a_Gemini.Models;
using VargasM_Conexión_a_Gemini.Repositories;

namespace VargasM_Conexión_a_Gemini.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IChatBotService _chatBotService;

        public HomeController(ILogger<HomeController> logger, IChatBotService chatBotService)
        {
            _logger = logger;
            _chatBotService = chatBotService;
        }

        public async Task<IActionResult> Index()
        {
            string answer = await _chatBotService.GetChatbotResponse("Haz un resumen de la pelicula titanic");

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
