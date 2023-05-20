using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using UrlWebApp.Models;
using UrlWebApp.Services;

namespace UrlWebApp.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private PrettyUrlsStored _prettyUrlsStored = new PrettyUrlsStored(new DataService());
        private ShortenService shortenService = new ShortenService();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")] //defautl view --> empty path
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [Route("{alias}")] // would get any empty route where anything after / is passed --> localhost:23/anything 
        [HttpGet]
        public IActionResult RedirectToFullURL(string alias)
        {
            if (string.IsNullOrEmpty(alias))
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            var longUrl = this._prettyUrlsStored.GetLongUrl(alias);

            if (longUrl == null)
                return View("Error", new ErrorViewModel { Message = "Nope!" });

            return Redirect(longUrl);
        }

        [Route("createnew")]
        [HttpPost]
        public IActionResult Create()
        {
            var longUrl = HttpContext.Request.Form["longUrl"];
            var alias = HttpContext.Request.Form["alias"];
            var isGood = this.shortenService.IsAliasValid(alias);

            if (!isGood)
                return View("Error", new ErrorViewModel { Message = "Nope! alias is invalid" });

            var newUrlModel = this.shortenService.CreateNewPrettyURL(longUrl, alias);

            return View("PrettyResult", newUrlModel);
        }

        [Route("PrettyResult")]
        [HttpGet]
        public IActionResult PrettyResult(URLViewModel newUrlModel)
        {
            return View();
        }

        [Route("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}