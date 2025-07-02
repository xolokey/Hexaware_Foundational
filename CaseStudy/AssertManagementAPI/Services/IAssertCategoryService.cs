using AssertManagementAPI.DTO.Assert;
using AssertManagementAPI.DTO.AssertCategory;

namespace AssertManagementAPI.Services
{
    public interface IAssertCategoryService
    {
        public Task<List<AssertCategoryDTO>> GetAllCategory();
        public Task<AssertCategoryDTO> GetCategoryById(int id);
        public Task<string> CreateCategory(CreateAssertCategoryDTO dto);
        public Task<string> DeleteCategory(int Id);
        public Task<string> UpdateCategory(UpdateAssertCategoryDTO dto, int Id);
    }
}
