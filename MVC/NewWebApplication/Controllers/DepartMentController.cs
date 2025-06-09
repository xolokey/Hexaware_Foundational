using Microsoft.AspNetCore.Mvc;

namespace NewWebApplication.Controllers
{
    public class DepartMentController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Name"] = "Lokey";
            ViewData["Domain"] = " .Net FSD";
            ViewBag.CompanyName = "Hexaware";
            return View();
        }
    }
}
