using AssertManagementMVC.Models;
using AssetManagementMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AssertManagementMVC.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        public readonly AssertManagementMvcContext _context;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public HomeController(AssertManagementMvcContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dashboard = new DashboardViewModel
            {
                TotalUsers = _context.Users.Count(),
                TotalAssets = _context.Assets.Count(),
                AllocatedAssets = _context.EmployeeAssets.Count(e => e.Status == "Allocated"),
                ActiveRequests = _context.ServiceRequests.Count(r => r.Status != "Resolved"),
                PendingAudits = _context.AuditRequests.Count(a => a.AuditStatus == "Pending")
            };

            return View("Index", dashboard);
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
