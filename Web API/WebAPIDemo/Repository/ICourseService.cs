using WebAPIDemo.Models;

namespace WebAPIDemo.Repository
{
    public interface ICourseService
    {
        public List<Course> GetAllCourse();
        public Course AddCourse(Course course);
        public string UpdateCourse(Course course);
        public string DeleteCourse(int courseId);
        public Course GetCourseById (int courseId);

    }
}




