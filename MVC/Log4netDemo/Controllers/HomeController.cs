using System.Diagnostics;
using Log4netDemo.Models;
using Microsoft.AspNetCore.Mvc;
using log4net;
using System.Linq.Expressions;
namespace Log4netDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly ILog logger1=LogManager.GetLogger(typeof(HomeController));
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            logger1.Info("Index page visited");
            try
            {
                throw new Exception("Test Exception");
            }
            catch (Exception ex)
            {
                logger1.Error("Something went wrong", ex);
            }
            return View();
        }
        public JsonResult GetjsonResult()
        {
            var data = new { Name = "lokey", Age=30,Occupation="Software Dev"};
            return Json(data);
        }

        public ContentResult GetContentResult()
        {
            string content = "Hello";
            return Content(content);
        }

        public IActionResult RedirectToGoogle()
        {
            return Redirect("https://www.google.com/");
        }
        public IActionResult RedirectToPrivacy()
        {
            return RedirectToAction("Privacy","Home");
        }
        public IActionResult DownloadTheFile()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes("wwwroot/sample.txt");
            return File(fileBytes,"application/octet-stream","sample.txt");

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
    }
}
