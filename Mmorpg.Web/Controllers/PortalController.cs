using Microsoft.AspNetCore.Mvc;

namespace Mmorpg.Web.Controllers
{
    public class PortalController : Controller
    {
        [HttpGet]
        public IActionResult Download()
        {
            ViewData["Title"] = "Download";
            return View();
        }

        [HttpGet]
        public IActionResult Loja()
        {
            ViewData["Title"] = "Loja";
            return View();
        }
    }
}
