
using EF_Employee.DBContect;
using Microsoft.AspNetCore.Mvc;

namespace EF_Employee.Controllers
{
    public class EmployeesController : Controller
    {
        public readonly AppDBContext _context;

        public EmployeesController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        public IActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(Models.Employee employee)
        {
            if (ModelState.IsValid) 
            { 
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
            
        }
        public IActionResult Details(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e=> e.EmployeeID == id);
            if (employee == null)
            {
                 return NotFound();
            }
            return View(employee);
        }
        //Edit Employee
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Models.Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        //Delete Employee
        public IActionResult Delete(int id)
        {
            var employee =_context.Employees.FirstOrDefault(e=>e.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult Delete(Models.Employee employee)
        {
            //var employee = _context.Employees.FirstOrDefault(e => e.EmployeeID == employee.EmployeeID);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
