using WebAPIDemo.Models;
using Microsoft.EntityFrameworkCore;
using WebAPIDemo.DBContext;

namespace WebAPIDemo.Repository
{
   
    public class StudentService : IStudentService
    {

        public readonly AppDBContext _context;
        public StudentService(AppDBContext context)
        {
            _context = context;
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public int AddStudent(Student student)
        {
            if (student != null)
            {
                _context.Students.Add(student);
                return student.StudentId;
            }
            else
                return 0;
        }

        public string DeleteStudent(int studentId)
        {
            var student = _context.Students.Where(s => s.StudentId == studentId).FirstOrDefault();
            if (student != null)
            {
                _context.Students.Remove(student);
                return $"{student.StudentName} Removed";
            }
            else
            {
                return "Id Not Present in the DataBase";
            }
        }

        public Student GetStudent(int StudentID)
        {
            var student = _context.Students.Where(s => s.StudentId == StudentID).FirstOrDefault();
            if (student == null)
            {
                return null;
            }
            else
            {
                return student;
            }
        }

        public string UpdateStudent(Student student)
        {
            var existingStudent = _context.Students.FirstOrDefault(s => s.StudentId == student.StudentId);
            if (existingStudent != null)
            {
                existingStudent.StudentName = student.StudentName;
                existingStudent.StudentAge = student.StudentAge;
                existingStudent.StudentGender = student.StudentGender;
                existingStudent.StudentCity = student.StudentCity;
                existingStudent.StudentEmail = student.StudentEmail;
                existingStudent.StudentCourse = student.StudentCourse;
                existingStudent.CourseId = student.CourseId;

                _context.SaveChanges();
                return $"{student.StudentName} Updated Successfully";
            }
            else
            {
                return "Id Not Present in the DataBase";
            }
        }

        public Student GetStudentByName(string StudentName)
        {
            var student = _context.Students
                .Where(s => s.StudentName != null &&
                            s.StudentName.ToLower(System.Globalization.CultureInfo.CurrentCulture) == StudentName.ToLower(System.Globalization.CultureInfo.CurrentCulture))
                .FirstOrDefault();
            if (student == null)
            {
                return null;
            }
            return student;
        }

        public List<Student> GetStudentByCourseOrCity(string course, string city)
        {
            var filteredStudents = _context.Students.AsQueryable();

            if (!string.IsNullOrWhiteSpace(course))
            {
                filteredStudents = filteredStudents.Where(s =>s.StudentCourse.Equals(course, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(city))
            {
                filteredStudents = filteredStudents.Where(s =>s.StudentCity.Equals(city, StringComparison.OrdinalIgnoreCase));
            }
            return filteredStudents.ToList();
            
        }


        public List<Student> GetStudentsByIdAndName(string StudentName, int StudentId)
        {
            var filterstudents = new List<Student>();
            if (!string.IsNullOrEmpty(StudentName))
            {
                filterstudents = _context.Students.Where(s => s.StudentName.Equals(StudentName, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (StudentId > 0) 
            {
                filterstudents.AddRange(_context.Students.Where(s => s.StudentId == StudentId).ToList());
            }
            return filterstudents; 
        }
        
    }
}
