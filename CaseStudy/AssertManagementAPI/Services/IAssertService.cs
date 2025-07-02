using AssertManagementAPI.DTO.Assert;
using AssertManagementAPI.Model;

namespace AssertManagementAPI.Services
{
    public interface IAssertService
    {
        public Task<List<AssertDTO>> AllAssert();
        public Task<AssertDTO> AssertById(int id);
        public Task<List<AssertDTO>> AssertByName(string name);
        public Task<List<AssertDTO>> AssertByStatus(string status);
        public Task<List<AssertDTO>> AssertByAssertNo(string assertNo);
        public Task<string> Create(CreateAssertDTO dto);
        public Task<string> Delete(int Id);
        public Task<string> Update(UpdateAssertDTO dto,int Id); 

    }
}
