using Microsoft.AspNetCore.Mvc;
using NewWebApplication.Models;
using System.Xml.Linq;

namespace NewWebApplication.Controllers
{
    public class DepartMentsController : Controller
    {
        public static List<Department> deptList = new List<Department>()
        {
                new Department() { Id = 102,Name = "Tester",Location = "Bengalur"},
                new Department() { Id = 103, Name = "Developer",Location = "Mumbai"},
                new Department() { Id = 104,Name = "Software Engineer",Location = "Mumbai"},
                new Department() { Id = 105,Name = "HR", Location = "Chennai"}

        };
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
        public IActionResult Department()
        { 
            return View(deptList);
        }
        //To Get from use and to insert in the Table
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            //deptList =new List<Department>();
            deptList.Add(department);
            return RedirectToAction("Department");
     
        }
        public IActionResult Details(int Id)
        {
            var departmentDetails = deptList.FirstOrDefault(d=>d.Id==Id);
            return PartialView("_DepartmentDetails",departmentDetails);
        }
    }
}
