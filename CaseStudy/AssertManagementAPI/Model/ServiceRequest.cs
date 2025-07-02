using System.ComponentModel.DataAnnotations;

namespace AssertManagementAPI.Model
{
    namespace AssetManagementAPI.Models
    {
        public class ServiceRequest
        {
            [Key]
            public int RequestId { get; set; }
            public string? Description { get; set; }
            public required string IssueType { get; set; }
            public required string Status { get; set; }
            [DataType(DataType.DateTime)]
            public DateTime RequestedDate { get; set; }
            [DataType(DataType.DateTime)]
            public DateTime? ResolvedDate { get; set; }
            public required int AssetId { get; set; }
            public Assert? Assert { get; set; }
            public int UserId { get; set; }
            public Employee? User { get; set; }
            public bool IsActive { get; set; }
        }
    }
}
