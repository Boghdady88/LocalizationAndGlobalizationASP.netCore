using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;
using WebApplication.Services;
using static WebApplication.Services.Enumrations;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LocService _sharedLocalizer;
        public HomeController(ILogger<HomeController> logger , LocService SharedLocalizer)
        {
            _logger = logger;
            _sharedLocalizer = SharedLocalizer;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult SetLanguage(string culture)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            switch (culture.ToLower())
            {
                case nameof(Languages.ar):
                    AppSession.IsArabic = true;
                    AppSession.IsEngligh = false;
                    break;
                case nameof(Languages.en):
                    AppSession.IsEngligh = true;
                    AppSession.IsArabic = false;
                    break;
                default:
                    break;
            }
            return Json("");
        }
    }
}
