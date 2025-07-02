using AssertManagementAPI.DTO.AuditRequest;
using AssertManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssertManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditRequestsController : ControllerBase
    {
        private readonly IAuditRequestService _service;
        public AuditRequestsController(IAuditRequestService auditRequestService)
        {
            _service = auditRequestService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("AllAuditRequest")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var request = await _service.AllRequests();
                return request != null? Ok(request) : NotFound("No Audit Request Listed!!");
            }
            catch (Exception ex) { throw new Exception($"Error While fetching Details:{ex.Message}"); }
        }
        [HttpGet("GetRequestById/{Id:int}")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                var request = await _service.GetByRequestId(Id);
                return request != null? Ok(request) : NotFound("Audit Request With ID NotFound!!");
            }
            catch (Exception ex) { throw new Exception($"Error While fetching Details:{ex.Message}"); }
        }
        [HttpPost("CreateAuditRequest")]
        public async Task<IActionResult> Create([FromBody]CreateAuditRequestDTO dto)
        {
            try
            {
                var request = await _service.AddRequest(dto);
                if (dto != null)
                {
                    return Ok(request);
                }
                return BadRequest("Enter the Required Details to create a request!!");
            }
            catch (Exception ex) { throw new Exception($"Error While fetching Details:{ex.Message}"); }
        }
        [Authorize(Roles ="Admin")]
        [HttpPut("UpdateRequest/{Id:int}")]
        public async Task<IActionResult> Update([FromBody]UpdateAuditRequestDTO dto,int Id)
        {
            try
            {
                var updaterequest = await _service.UpdateRequest(dto,Id);
                if (dto != null)
                {
                    return Ok(updaterequest);
                }
                return BadRequest("Enter the valid ID to Update a Request");
            }
            catch (Exception ex) { throw new Exception($"Error While fetching Details:{ex.Message}"); }
        }
        [Authorize(Roles ="Admin")]
        [HttpDelete("Delete/{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var delrequest = await _service.DeleteRequest(Id);
                if (delrequest != null)
                {
                    return Ok(delrequest);
                }
                return BadRequest("Enter the valid ID to Delete a Request");
            }
            catch (Exception ex) { throw new Exception($"Error While fetching Details:{ex.Message}"); }
        }
    }
}
