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
