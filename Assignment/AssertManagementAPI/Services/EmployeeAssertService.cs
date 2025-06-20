
using AssertManagementAPI.Context;
using AssertManagementAPI.DTO.EmployeeAssert;
using AssertManagementAPI.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AssertManagementAPI.Services
{
    public class EmployeeAssertService:IEmployeeAssertService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public EmployeeAssertService(AppDbContext context,IMapper mapper)
        { 
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EmployeeAssertDTO>> GetEmpAsserts()
        {
            try
            {
                var emp = await _context.EmployeeAsserts.Where(e => e.IsActive)
                    .Select(e => new EmployeeAssertDTO
                    {
                        AllocationId = e.AllocationId,
                        UserId = e.UserId,
                        AssetId = e.AssetId,
                        AllocationDate = e.AllocationDate,
                        ReturnDate = e.ReturnDate,
                        IsActive = e.IsActive,
                    })
                    .ToListAsync();
                return emp;


            }
            catch (Exception ex) { throw new Exception($"Error While Fetching Employee Assert Details:{ex.Message}"); }
        }
        public async Task<EmployeeAssertDTO> GetEmpAssertById(int empId)
        {
            try
            {
                var emp = await _context.EmployeeAsserts.Where(e=> e.AllocationId == empId && e.IsActive).FirstOrDefaultAsync();
                if (emp != null)
                {
                    return _mapper.Map<EmployeeAssertDTO>(emp);
                }
                else
                    return null;

            }
            catch (Exception ex) { throw new Exception($"Error While Fetching Employee Assert Details:{ex.Message}"); }
        }
        public async Task<string> Create(CreateEmployeeAssertDTO empDTO)
        {
            try
            {
                if (empDTO != null)
                {
                    var emp = new EmployeeAssert
                    {
                        UserId = empDTO.UserId,
                        AssetId = empDTO.AssetId,
                        AllocationDate = empDTO.AllocationDate,
                        ReturnDate = empDTO.ReturnDate,
                        IsActive = empDTO.IsActive,
                    };
                    await _context.AddAsync(emp);
                    await _context.SaveChangesAsync();
                    return "....Employee Assert Created Successfully...";
                }
                else return "Enter the Required Details To Create Employee assert Details";

            }
            catch (Exception ex) { throw new Exception($"Error While Adding Employee Assert: {ex.Message}"); }

        }
        public async Task<string> Update(int empId, UpdateEmployeeAssertDTO empDTO)
        {
            try
            {
                var emp = await _context.EmployeeAsserts.Where(e=> e.AllocationId == empId && e.IsActive).FirstOrDefaultAsync();
                if (emp != null) 
                {
                    emp.AssetId = empDTO.AssetId;
                    emp.UserId = empDTO.UserId;
                    emp.AllocationDate = empDTO.AllocationDate;
                    emp.ReturnDate = empDTO.ReturnDate;
                    await _context.SaveChangesAsync();
                    return $"....Employee Assert Details with ID:{empId} Updated Successfully....";
                }
                return "User With ID Not Found!!";
            }
            catch (Exception ex) { throw new Exception($"Error While Updating Employee Assert:{ ex.Message }"); }
        }
        public async Task<string> Delete(int Id)
        {
            try
            {
                var emp = await _context.EmployeeAsserts.Where(e=> e.AllocationId == Id).FirstOrDefaultAsync();
                if (emp != null) 
                {
                    emp.IsActive = false;
                    await _context.SaveChangesAsync();
                    return $"....Employee Assert Details With AllocationID:{Id} Deleted....";
                }
                return $"No Employee Assert Details With ID:{Id}!!";

            }
            catch (Exception ex) { throw new Exception($"Error While Deleting Employee Assert Record{ex.Message}"); }
        }
    }

}
