using WebAPIDemo.Models;

namespace WebAPIDemo.Repository
{
   
public class StudentService : IStudentService
    {
        public static List<Student> students = new List<Student>()
        {
            // Example initialization
            new Student { StudentId = 1, StudentName = "John Doe", StudentAge = 16,StudentGender="Male", StudentCity = "Chennai", StudentEmail = "john.doe@example.com", StudentCourse = "Math" },
            new Student { StudentId = 2, StudentName = "Jane Smith", StudentAge = 17,StudentGender="Male", StudentCity = "Banglore", StudentEmail = "jane.smith@example.com", StudentCourse = "Science" },
            new Student { StudentId = 3, StudentName = "Mowny", StudentAge = 17,StudentGender="Female", StudentCity = "Chennai", StudentEmail = "jane.smith@example.com", StudentCourse = "Math" },
            new Student { StudentId = 4, StudentName = "Lokey", StudentAge = 17,StudentGender="Male", StudentCity = "Banglore", StudentEmail = "jane.smith@example.com", StudentCourse = "Science" }
            
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
            var student = students.Where(s => s.StudentId == studentId).FirstOrDefault();
            if (student != null)
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

        public Student GetStudentByName(string StudentName)
        {
            var student = students.Where(s => s.StudentName?.ToLower() == StudentName.ToLower()).FirstOrDefault();
            if (student == null)
            {
                return null;
            }
            return student;
        }

        public List<Student> GetStudentByCourseOrCity(string course, string city)
        {
            var filteredStudents = students.AsQueryable();

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
                filterstudents = students.Where(s => s.StudentName.Equals(StudentName, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (StudentId > 0) 
            {
                filterstudents.AddRange(students.Where(s => s.StudentId == StudentId).ToList());
            }
            return filterstudents; 
        }
        
    }
}
