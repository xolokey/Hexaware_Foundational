using Microsoft.AspNetCore.Mvc;
using System;
using EF_CodeFirstDemo.DBContext;

namespace EF_CodeFirstDemo.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ApplicationDBContext _context;
        public DepartmentsController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
