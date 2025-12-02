using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Mmorpg.Web.Controllers
{
    public class LanguageController : Controller
    {
        [HttpGet]
        public IActionResult Set(string culture, string? returnUrl = "/")
        {
            if (string.IsNullOrWhiteSpace(culture))
            {
                culture = "pt";
            }

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1),
                    IsEssential = true
                }
            );

            if (string.IsNullOrWhiteSpace(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                returnUrl = Url.Action("Index", "Home") ?? "/";
            }

            return LocalRedirect(returnUrl);
        }
    }
}
