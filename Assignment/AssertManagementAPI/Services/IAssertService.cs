using AssertManagementAPI.DTO.Assert;
using AssertManagementAPI.Model;

namespace AssertManagementAPI.Services
{
    public interface IAssertService
    {
        public List<AssertDTO> AllAssert();
        public AssertDTO AssertById(int id);
        public List<AssertDTO> AssertByName(string name);
        public List<AssertDTO> AssertByStatus(string status);
        public List<AssertDTO> AssertByAssertNo(string assertNo);
        public string Create(CreateAssertDTO dto);
        public string Delete(int Id);
        public string Update(UpdateAssertDTO dto,int Id); 

    }
}
