using System.ComponentModel.DataAnnotations;

namespace WebAPIDemo.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string? CourseName {  get; set; }
        public string? CourseDuration { get; set; }
        public string? CourseType { get; set; }
        public bool isActive {  get; set; }=true;

        //public ICollection<Student> Student { get; set; }

    }
}
