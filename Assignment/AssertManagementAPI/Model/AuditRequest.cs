using System.ComponentModel.DataAnnotations;

namespace AssertManagementAPI.Model
{
    public class AuditRequest
    {
        [Key]
        public int AuditRequestId { get; set; }

        public required int AssetId { get; set; }
        public Assert? Assert { get; set; }

        public required int UserId { get; set; }
        public User? User { get; set; }

        [RegularExpression(@"^Completed|InProcess|UnCompleted|Other", ErrorMessage = "Enter a Valid Status as Completed or InProcess")]
        public required string AuditStatus { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? AuditDate { get; set; }

        public ICollection<AssertAuditLogs> AssertAuditLogs { get; set; } = new List<AssertAuditLogs>();
    }
}
