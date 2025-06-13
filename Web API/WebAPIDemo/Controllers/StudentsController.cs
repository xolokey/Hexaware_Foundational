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
        public List<Student> GetAllStudents()
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

        [HttpGet("GetStudent/{StudentId:int}")]
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

        [HttpPut("UpdateStudent/{StudentId:int}")]

        public IActionResult UpdateStudent(int StudentId,Student student)
        {
            var result = _studentService.UpdateStudent(student);
            return Ok(result);
        }
        [HttpDelete("Delete/{StudentId:int}")]
        public IActionResult DeleteStudent(int StudentId)
        {
            var result = _studentService.DeleteStudent(StudentId);
            return Ok(result);
        }

        [HttpGet("GetStudentByName{StudentName}")]
        public IActionResult GetStudentByName(string StudentName)
        {
            try
            {

                var student = _studentService.GetStudentByName(StudentName);
                if (student == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(student);
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        [HttpGet("GetStudentByCourseOrCity")]
        public IActionResult GetStudentByCourseOrCity([FromQuery] string? course, [FromQuery] string? city)
        {
            try
            {
                var student = _studentService.GetStudentByCourseOrCity(course, city);
                if (student != null)
                {
                    return Ok(student);
                }
                else
                {
                    
                    return NotFound();
                }
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetStudentByIdAndName")]
        public IActionResult GetStudentByIdAndName([FromQuery] int StudentId, [FromQuery]string? StudentName)
        {
            var student = _studentService.GetStudentsByIdAndName(StudentName, StudentId);
            if (student == null)
            {
                return NotFound($"Student with {StudentName} and {StudentId} Not Found!!!");
            }
            else { return Ok(student); }
        }

    }
}
