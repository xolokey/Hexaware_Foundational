using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Models;
using WebAPIDemo.Repository;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("GetAllCourses")]
        public IActionResult GetAllCourses()
        {
            var courses = _courseService.GetAllCourse();
            return Ok(courses);
        }

        [HttpGet("GetCourseById/{id}")]
        public IActionResult GetCourseById(int id)
        {
            var course = _courseService.GetCourseById(id);
            if (course == null)
                return NotFound("Course not found");

            return Ok(course);
        }

        [HttpPost("AddCourse")]
        public IActionResult AddCourse([FromBody] Course course)
        {
            var id = _courseService.AddCourse(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = id }, course);
        }

        [HttpPut("UpdateCourse")]
        public IActionResult UpdateCourse([FromBody] Course course)
        {
            try
            {

                var result = _courseService.UpdateCourse(course);
                return Ok($"The Course Was Updated SuccessFully!! {result}");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("DeleteCourse/{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var result = _courseService.DeleteCourse(id);
            return Ok(result);
        }
    }
}
