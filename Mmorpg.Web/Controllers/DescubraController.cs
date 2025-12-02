using Microsoft.AspNetCore.Mvc;

namespace Mmorpg.Web.Controllers
{
    public class DescubraController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Title"] = "Descubra";
            return View();
        }

        [HttpGet]
        public IActionResult Guias()
        {
            ViewData["Title"] = "Guias";
            return View();
        }

        [HttpGet]
        public IActionResult BuildsBasicas()
        {
            ViewData["Title"] = "Builds Básicas";
            return View();
        }

        [HttpGet]
        public IActionResult PerguntasFrequentes()
        {
            ViewData["Title"] = "Perguntas Frequentes";
            return View();
        }

        [HttpGet]
        public IActionResult Videos()
        {
            ViewData["Title"] = "Vídeos";
            return View();
        }

        [HttpGet]
        public IActionResult Historia()
        {
            ViewData["Title"] = "História";
            return View();
        }

        [HttpGet]
        public IActionResult Wallpapers()
        {
            ViewData["Title"] = "Wallpapers";
            return View();
        }

        [HttpGet]
        public IActionResult Trabalhos()
        {
            ViewData["Title"] = "Trabalhos";
            return View();
        }
    }
}
