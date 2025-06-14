using WebAPIDemo.Models;
using WebAPIDemo.DBContext;

namespace WebAPIDemo.Repository
{
    public class CourseService : ICourseService
    {
        private readonly AppDBContext _context;

        public CourseService(AppDBContext context)
        {
            _context = context;
        }

        public List<Course> GetAllCourse()
        {
            return _context.Courses.ToList();
        }

        public Course GetCourseById(int courseId)
        {
            try
            {
                var course = _context.Courses.Where(c=>c.CourseId == courseId).FirstOrDefault();
                if (course != null)
                {
                    return course;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            
            }
        }

        public Course AddCourse(Course course)
        {
            try
            {
                if (course != null)
                {
                    _context.Courses.Add(course);
                    _context.SaveChanges();
                    return course;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
                
            }
        }

        public string UpdateCourse(Course course)
        {
            try
            {
                var existingCourse = _context.Courses.Find(course.CourseId);
                if (existingCourse != null)
                {

                    existingCourse.CourseName = course.CourseName;
                    existingCourse.CourseDuration = course.CourseDuration;
                    existingCourse.CourseType = course.CourseType;

                    _context.SaveChanges();
                    return "Course Updated Successfully";
                }
                else
                {
                    return "This CourseId is Not Found in DataBase";
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string DeleteCourse(int courseId)
        {
            try
            {
                var course = _context.Courses.Find(courseId);
                if (course != null)
                { 
                    //course.isActive = false;
                    _context.Courses.Remove(course);
                    _context.SaveChanges();
                    return "Course Deleted Successfully"; 
                }
                else
                {

                    return $"Course With {courseId} Not Found!";
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
