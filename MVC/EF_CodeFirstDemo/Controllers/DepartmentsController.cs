using Microsoft.AspNetCore.Mvc;
using System;
using EF_CodeFirstDemo.DBContext;
using EF_CodeFirstDemo.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace EF_CodeFirstDemo.Controllers
{
    public class DepartmentsController : Controller
    {
        public readonly ApplicationDBContext _context;

        public DepartmentsController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }


        public IActionResult Details(int Id)
        {
            var department = _context.Departments.Find(Id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }


        //To Create a New Data to DB table
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Models.Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return  View(department);
        }

        //To Edit the Data in DataBase
        public IActionResult Edit(int id)
        {
            var department = _context.Departments.FirstOrDefault(d=>d.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Department department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                { 
                    return BadRequest(ex.Message);
                }
                
            }
            return View(department);
        }
        //To Delete Data in the Table
        public IActionResult Delete(int id) 
        { 
            var department = _context.Departments.FirstOrDefault(d=>d.Id==id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id,Department department) 
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Remove(department);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                { 
                    return BadRequest(ex.Message);
                
                }
                

            }
            return View(department);
        }
    }
}
