using System.ComponentModel.DataAnnotations;

namespace AssertManagementAPI.DTO.ServiceRequest
{
    public class ServiceRequestDTO
    {
        public int RequestId { get; set; }
        public string? Description { get; set; }
        public required string IssueType { get; set; }
        public required string Status { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime RequestedDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ResolvedDate { get; set; }
        public required int AssetId { get; set; }
        public int UserId { get; set; }
        public bool IsActive {  get; set; }
    }
}
