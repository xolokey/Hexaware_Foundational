using System.ComponentModel.DataAnnotations;

namespace AssertManagementAPI.DTO.AuditRequest
{
    public class CreateAuditRequestDTO
    {
        public required int AssetId { get; set; }
        public required int UserId { get; set; }
        [RegularExpression(@"^Completed|InProcess|UnCompleted|Other", ErrorMessage = "Enter a Valid Status as Completed or InProcess")]
        public required string AuditStatus { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? AuditDate { get; set; }
        public bool IsActive { get; set; }
    }
}
