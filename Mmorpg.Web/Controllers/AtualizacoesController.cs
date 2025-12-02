using Microsoft.AspNetCore.Mvc;

namespace Mmorpg.Web.Controllers
{
    public class AtualizacoesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Title"] = "Atualizações";
            return View();
        }

        [HttpGet]
        public IActionResult NotasDePatch()
        {
            ViewData["Title"] = "Notas de Patch";
            return View();
        }

        [HttpGet]
        public IActionResult Eventos()
        {
            ViewData["Title"] = "Eventos";
            return View();
        }

        [HttpGet]
        public IActionResult Temporadas()
        {
            ViewData["Title"] = "Temporadas";
            return View();
        }

        [HttpGet]
        public IActionResult Hotfixes()
        {
            ViewData["Title"] = "Hotfixes";
            return View();
        }
    }
}
