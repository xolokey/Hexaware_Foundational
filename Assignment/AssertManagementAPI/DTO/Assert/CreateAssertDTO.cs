﻿using System.ComponentModel.DataAnnotations;

namespace AssertManagementAPI.DTO.Assert
{
    public class CreateAssertDTO
    {
        public required string AssetNo { get; set; }
        public required string AssetName { get; set; }
        public required string AssetModel { get; set; }
        public required string Status { get; set; }
        public decimal? AssetValue { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ManufacturingDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ExpiryDate { get; set; }
        public int CategoryId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
