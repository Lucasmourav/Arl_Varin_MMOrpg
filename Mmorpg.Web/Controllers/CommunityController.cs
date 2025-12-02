using Microsoft.AspNetCore.Mvc;

namespace Mmorpg.Web.Controllers
{
    public class CommunityController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Title"] = "Comunidade";
            return View();
        }

        [HttpGet]
        public IActionResult Forum()
        {
            ViewData["Title"] = "Fórum";
            return View();
        }

        [HttpGet]
        public IActionResult Wiki()
        {
            ViewData["Title"] = "Wiki";
            return View();
        }

        [HttpGet]
        public IActionResult ProgramaDeCriadores()
        {
            ViewData["Title"] = "Programa de Criadores";
            return View();
        }

        [HttpGet]
        public IActionResult TwitchDrops()
        {
            ViewData["Title"] = "Twitch Drops";
            return View();
        }

        [HttpGet]
        public IActionResult QuadroDeMortes()
        {
            ViewData["Title"] = "Quadro de Mortes";
            return View();
        }

        [HttpGet]
        public IActionResult CriadorDePersonagem()
        {
            ViewData["Title"] = "Criador de Personagem";
            return View();
        }
    }
}
