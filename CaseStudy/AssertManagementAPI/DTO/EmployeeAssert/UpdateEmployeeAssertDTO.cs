using System.ComponentModel.DataAnnotations;

namespace AssertManagementAPI.DTO.EmployeeAssert
{
    public class UpdateEmployeeAssertDTO
    {
        public required int UserId { get; set; }
        public required int AssetId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? AllocationDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ReturnDate { get; set; }
        public bool IsActive { get; set; }
    }
}
