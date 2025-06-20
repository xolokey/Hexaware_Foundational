using AssertManagementAPI.DTO.EmployeeAssert;

namespace AssertManagementAPI.Services
{
    public interface IEmployeeAssertService
    {
        public Task<List<EmployeeAssertDTO>> GetEmpAsserts();
        public Task<EmployeeAssertDTO> GetEmpAssertById(int empId);
        public Task<string> Create(CreateEmployeeAssertDTO empAssertDTO);
        public Task<string> Update(int Id, UpdateEmployeeAssertDTO empAssertDTO);
        public Task<string> Delete(int Id);
    }
}
