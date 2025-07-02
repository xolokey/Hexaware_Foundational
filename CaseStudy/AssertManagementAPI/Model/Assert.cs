using AssertManagementAPI.Model.AssetManagementAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssertManagementAPI.Model
{
    public class Assert
    {
        [Key]
        public int AssetId { get; set; }

        public required string AssetNo { get; set; }
        public required string AssetName { get; set; }
        public required string AssetModel { get; set; }
        public required string Status { get; set; }
        public required string ImageURL { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? AssetValue { get; set; }

        public int AssertQuantity { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ManufacturingDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ExpiryDate { get; set; }

        public int CategoryId { get; set; }
        public AssertCategory? Category { get; set; }

        public bool IsAvailable { get; set; }

        public ICollection<AuditRequest>? AuditRequests { get; set; } = new List<AuditRequest>();
        public ICollection<EmployeeAssert>? EmployeeRequests { get; set; } = new List<EmployeeAssert>();
        public ICollection<ServiceRequest>? ServiceRequests { get; set; } = new List<ServiceRequest>();
    }
}
