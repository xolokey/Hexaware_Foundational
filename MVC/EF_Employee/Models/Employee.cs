namespace EF_Employee.Models
{
    public class Employee
    {
        public int EmployeeID {  get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber {  get; set; }
        public string? Address { get; set; }
        public decimal? Amount { get; set; }

    }
}
