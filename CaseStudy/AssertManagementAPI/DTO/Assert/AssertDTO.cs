using System.ComponentModel.DataAnnotations;

namespace AssertManagementAPI.DTO.Assert
{
    public class AssertDTO
    {
        public int AssetId { get; set; }
        public required string AssetNo { get; set; }
        public required string AssetName { get; set; }
        public required string AssetModel { get; set; }
        public required string ImageURL { get; set; }
        public required string Status { get; set; }
        public decimal? AssetValue { get; set; }
        public int AssertQuantity { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ManufacturingDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ExpiryDate { get; set; }
        public int CategoryId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
