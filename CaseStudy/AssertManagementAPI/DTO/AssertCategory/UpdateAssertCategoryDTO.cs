
namespace AssertManagementAPI.DTO.AssertCategory
{
    public class UpdateAssertCategoryDTO
    {
        public required string CategoryName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
