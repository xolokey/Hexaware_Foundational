using System.ComponentModel.DataAnnotations;

namespace AssertManagementAPI.Model
{
    public class AssertAuditLogs
    {
        [Key]
        public int LogId { get; set; }

        public int AuditRequestId { get; set; }
        [RegularExpression(@"^Completed|InProcess|UnCompleted|Other", ErrorMessage = "Enter a Valid Status as Completed or InProcess")]
        public required string Status { get; set; }

        public int? VerifiedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? VerifiedDate { get; set; }

        public  AuditRequest? AuditRequest { get; set; }

        public  Employee? VerifiedByNavigation { get; set; }
    }
}
