using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_CodeFirstDemo.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Name Can't Be Blank")]
        [StringLength(50)]
        public string? EmployeeName { get; set; }
        [Required(ErrorMessage = "Email Can't Be Blank")]
        //[RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9_.+-]+\.[a-zA-Z0-9_.+-]+$"), ErrorMessage ="Please enter a valid Emal"]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        public string? Location { get; set; }
        [RegularExpression(@"^Male|Female|Other", ErrorMessage = "Gender Can Only Be Male,Female,Other")]
        public string? Gender { get; set; }
        [DataType(DataType.Date)]
        public DateOnly DateofJoining { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Salary { get; set; }
        [Required(ErrorMessage ="Password Cant be Empty")]
        [StringLength(8,MinimumLength =8,ErrorMessage ="The Password must contain atlaest 8 Characters")]
        [DataType(DataType.Password)]
        public string? Password {  get; set; }
        [Required(ErrorMessage ="Confirm your PassWord")]
        [Compare("Password",ErrorMessage ="Dosnt Match")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword {  get; set; }

        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
