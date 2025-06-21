namespace AssertManagementAPI.DTO.AssertCategory
{
    public class AssertCategoryDTO
    {
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
