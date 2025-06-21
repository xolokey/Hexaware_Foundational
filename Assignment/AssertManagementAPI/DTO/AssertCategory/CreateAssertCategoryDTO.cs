
namespace AssertManagementAPI.DTO.AssertCategory
{
    public class CreateAssertCategoryDTO
    {
        public required string CategoryName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
