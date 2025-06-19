using AssertManagementAPI.DTO.Assert;
using AssertManagementAPI.Model;

namespace AssertManagementAPI.Services
{
    public interface IAssertService
    {
        public List<AssertDTO> AllAssert();
        public AssertDTO AssertById(int id);
        public List<AssertDTO> AssertByName(string name);

    }
}
