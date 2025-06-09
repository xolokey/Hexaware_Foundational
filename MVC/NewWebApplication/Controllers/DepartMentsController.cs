using Microsoft.AspNetCore.Mvc;
using NewWebApplication.Models;

namespace NewWebApplication.Controllers
{
    public class DepartMentsController : Controller
    {
        public IActionResult Index()
        {
            Department department = new Department();
            department.Id = 101;
            department.Name = "SoftWare Developer";
            department.Location = "Chennai";

            ViewData["Name"] = "Lokey";
            ViewData["Domain"] = " .Net FSD";
            ViewBag.CompanyName = "Hexaware";
            return View(department);
        }
    }
}
