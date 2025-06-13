using WebAPIDemo.Models;

namespace WebAPIDemo.Repository
{
   
    public class StudentService : IStudentService
    {
        public static  List<Student> students = new List<Student>()
        {
            // Example initialization
            new Student { StudentId = 1, StudentName = "John Doe", StudentEmail = "john.doe@example.com", StudentCourse = "Math" },
            new Student { StudentId = 2, StudentName = "Jane Smith", StudentEmail = "jane.smith@example.com", StudentCourse = "Science" }
        };

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public int AddStudent(Student student)
        {
            if (student != null)
            {
                students.Add(student);
                return student.StudentId;
            }
            else
                return 0;
        }

        public string DeleteStudent(int studentId)
        {
            var student = students.Where(s=>s.StudentId == studentId).FirstOrDefault();
            if(student != null)
            { 
                students.Remove(student);
                return $"{student.StudentName} Removed";
            }
            else
            {
                return "Id Not Present in the DataBase";
            }
        }


        public Student GetStudent(int StudentID)
        {
            var student = students.Where(s => s.StudentId == StudentID).FirstOrDefault();
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
            var index = students.FindIndex(s => s.StudentId == student.StudentId);
            if (index != -1)
            {
                students[index] = student;
                return $"{student.StudentName} Updated Successfully";
            }
            else
            {
                return "Id Not Present in the DataBase";

            }
        }
            
    }
}
