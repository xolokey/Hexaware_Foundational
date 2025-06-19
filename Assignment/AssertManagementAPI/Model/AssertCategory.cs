using System.ComponentModel.DataAnnotations;

namespace AssertManagementAPI.Model
{
    namespace AssetManagementAPI.Models
    {
        public class AssertCategory
        {
            [Key]
            public int CategoryId { get; set; }
            public required string CategoryName { get; set; }
            public string? Description { get; set; }
            public ICollection<Assert>? Assetrs { get; set; }= new List<Assert>();
        }
    }
}
