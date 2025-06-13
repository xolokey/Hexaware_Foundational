using WebAPIDemo.Models;
namespace WebAPIDemo.Repository
{
    public interface IStudentService
    {
        public List<Student> GetAllStudents();
        public int AddStudent(Student student);
        public string UpdateStudent(Student student);
        public string DeleteStudent(int studentID);
        public Student GetStudent(int studentID);

    }
}
