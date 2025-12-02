using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace Mmorpg.Web.Controllers
{
    public class PdfController : Controller
    {
        [HttpGet("pdf/sample")]
        public IActionResult Sample()
        {
            return new ViewAsPdf("Sample")
            {
                FileName = "sample.pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };
        }

        [HttpGet]
        public IActionResult Preview()
        {
            return View("Sample");
        }
    }
}
