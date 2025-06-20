
using AssertManagementAPI.DTO.Assert;
using AssertManagementAPI.DTO.EmployeeAssert;
using AssertManagementAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssertManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAssertsController : ControllerBase
    {
        private readonly IEmployeeAssertService _service;
        public EmployeeAssertsController(IEmployeeAssertService service)
        {
            _service = service;
        }
        [HttpGet("AllEmployeeAsserts")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var emp = await _service.GetEmpAsserts();
                return emp != null ? Ok(emp) : NotFound("No Employee Assert Records!!");

            }
            catch (Exception ex) { throw new Exception($"Error While Fetching Details{ex.Message}"); }
        }
        [HttpGet("EmployeeAssertByID/{Id:int}")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                var emp = await _service.GetEmpAssertById(Id);
                return emp != null ? Ok(emp) : NotFound("No Employee Assert Details With");
            }
            catch(Exception ex) { throw new Exception($"Error While Fetching Details{ex.Message}"); }
        }
        [HttpPost("AddEmployeeAssert")]
        public async Task<IActionResult> Add([FromBody] CreateEmployeeAssertDTO createdto)
        {
            try
            {
                var emp = await _service.Create(createdto);
                if(createdto != null)
                {
                    return Ok(emp);
                }
                return NotFound("Enter Required Details");

            }
            catch (Exception ex) { throw new Exception($"Error While fetching Details {ex.Message} !!"); }
        }
        [HttpDelete("DeleteEmployeeAssert/{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var emp = await _service.Delete(Id);
                return emp != null ? Ok(emp) : NotFound("No Matching Info/User with ID!!");

            }
            catch (Exception ex) { throw new Exception($"Error While fetching Details {ex.Message} !!"); }
        }
        [HttpPut("UpdateEmployeeAssert/{Id:int}")]
        public async Task<IActionResult> Update([FromBody]UpdateEmployeeAssertDTO updatedto,int Id)
        {
            try
            {
                var emp = await _service.Update(Id, updatedto);
                return emp != null ? Ok(emp) : NotFound("No User with ID Found!!");

            }
            catch (Exception ex) { throw new Exception($"Error While fetching Details {ex.Message} !!"); }
        }
    }
}
