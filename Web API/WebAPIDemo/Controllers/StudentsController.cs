using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Models;
using WebAPIDemo.Repository;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetAllStudent")]
        public async Task<List<Student>> GetAllStudents()
        {
            try
            {
                return _studentService.GetAllStudents();
            }
            catch 
            { 
                throw new Exception("Error while fetching students data");
            }
            
           
        }

        [HttpGet("GetStudent/{StudentId}")]
        public IActionResult GetStudent(int StudentId)
        {
            try
            {
                var student = _studentService.GetStudent(StudentId);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch(Exception ex)
            {
                throw new Exception($"Error while fetching student with ID {StudentId}: {ex.Message}");
            }
            
        }
        [HttpPost("AddStudent")]
        public IActionResult AddStudent(Student student)
        {
            var studentId = _studentService.AddStudent(student);
            if (studentId == 0)
            {
                return BadRequest("Invalid student data provided.");
            }
            return Ok($"student with {studentId} added");
        }

        [HttpPut("UpdateStudent/{StudentId}")]

        public IActionResult UpdateStudent(int StudentId,Student student)
        {
            var result = _studentService.UpdateStudent(student);
            return Ok(result);
        }
        [HttpDelete("{StudentId}")]
        public IActionResult DeleteStudent(int StudentId)
        {
            var result = _studentService.DeleteStudent(StudentId);
            return Ok(result);
        }
    }
}
