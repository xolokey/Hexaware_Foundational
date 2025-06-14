using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIDemo.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; } 
        public string? StudentName { get; set; }
        public int StudentAge { get; set; }
        [RegularExpression(@"^Male|Female|Other",ErrorMessage ="Gender can only be Male,Female or Other")]
        public string? StudentGender { get; set; }
        public string? StudentCity {  get; set; }

        [DataType(DataType.EmailAddress)]
        public string? StudentEmail { get; set; }
        public string? StudentCourse { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course? Course { get; set; }


    }
}
