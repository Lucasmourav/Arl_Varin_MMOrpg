using Microsoft.AspNetCore.Mvc;

namespace Mmorpg.Web.Controllers
{
    public class SuporteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Title"] = "Suporte";
            return View();
        }
    }
}
