using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Department.Models;
using Department.Repository;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    { 
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("GetAllDepartment")]
        public List<SubDepartment> GetAllDepartment()
        {
            try
            {
                return _departmentService.GetAllDepartments();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetDepartment{DepartmentId:int}")]

        public IActionResult GetDepartment(int DepartmentId)
        {

            try
            {
                var department = _departmentService.GetDepartment(DepartmentId);
                if (department == null) 
                {
                    return NotFound();

                }
                return Ok(department);
            }
            catch (Exception ex)
            { 

                throw new Exception(ex.Message);
            
            }
        }

        [HttpPost("CreateDepartment")]
        public IActionResult CreateDepartment(SubDepartment department)
        {
            try
            {
                var departmentId = _departmentService.CreateDepartment(department);
                if (departmentId == 0)
                {
                    return NotFound();
                }
                return Ok(department);
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message);
            
            }
        
        }

        [HttpDelete("DeleteDepartment{DepartmentId:int}")]
        public IActionResult DeleteDepartment(int DepartmentId)
        {
            try
            {
                var department = _departmentService.DeleteDepartment(DepartmentId);
                if (department == null)
                {
                    return NotFound();
                }
                return Ok(department);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut("UpdateDepartment{DepartmentId:int}")]

        public IActionResult UpdateDepartment(SubDepartment department)
        {
            try
            {
                var departmentId = _departmentService.UpdateDepartment(department);
                if (departmentId == null)
                {
                    return NotFound();
                }
                return Ok(department);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    

    
}
