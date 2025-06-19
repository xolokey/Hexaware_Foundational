using System.ComponentModel.DataAnnotations;

namespace AssertManagementAPI.Model
{
    public class EmployeeAssert
    {
        [Key]
        public int AllocationId {  get; set; }
        public required int UserId {  get; set; }
        public User? User { get; set; }
        public required int AssertId { get; set; }
        public Assert? Assert { get; set; }
        public required DateTime AllocationDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsActive { get; set; }=true;
        
    }
}
