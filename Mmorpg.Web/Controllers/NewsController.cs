using Microsoft.AspNetCore.Mvc;

namespace Mmorpg.Web.Controllers
{
    public class NewsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Title"] = "Notícias";
            return View();
        }

        [HttpGet]
        public IActionResult Ecos()
        {
            ViewData["Title"] = "Ecos do Mundo";
            return View();
        }

        [HttpGet]
        public IActionResult Comunicados()
        {
            ViewData["Title"] = "Comunicados Oficiais";
            return View();
        }

        [HttpGet]
        public IActionResult EventosAoVivo()
        {
            ViewData["Title"] = "Eventos ao Vivo";
            return View();
        }
    }
}
