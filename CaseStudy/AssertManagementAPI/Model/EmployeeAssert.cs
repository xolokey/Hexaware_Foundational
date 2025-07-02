using System.ComponentModel.DataAnnotations;

namespace AssertManagementAPI.Model
{
    public class EmployeeAssert
    {
        [Key]
        public int AllocationId {  get; set; }
        public required int UserId {  get; set; }
        public Employee? User { get; set; }
        public required int AssetId { get; set; }
        public Assert? Assert { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? AllocationDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ReturnDate { get; set; }
        public bool IsActive { get; set; }
        
    }
}
