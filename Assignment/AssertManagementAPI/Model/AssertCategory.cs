using System.ComponentModel.DataAnnotations;

namespace AssertManagementAPI.Model
{
    namespace AssetManagementAPI.Models
    {
        public class AssertCategory
        {
            public int CategoryId { get; set; }
            public required string CategoryName { get; set; }
            public string? Description { get; set; }
            public virtual ICollection<Assert>? Assetrs { get; set; }
        }
    }
}
