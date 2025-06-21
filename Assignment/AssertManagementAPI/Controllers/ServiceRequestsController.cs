using AssertManagementAPI.DTO.Assert;
using AssertManagementAPI.DTO.ServiceRequest;
using AssertManagementAPI.Services;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssertManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestsController : ControllerBase
    {
        private readonly IServiceRequestService _service;

        public ServiceRequestsController(IServiceRequestService service) 
        { 
            _service = service;
        }
        [HttpGet("AllServiceRequest")]
        public async Task<IActionResult> AllService()
        {
            try
            {
                var service = await _service.GetServiceRequests();
                return service != null ? Ok(service) : NotFound("No Service Request Found!!");
            }
            catch (Exception ex) { throw new Exception($"Error While Fetching Details:{ex.Message}"); }
        }
        [HttpGet("ServiceRequestById/{Id:int}")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                var service = await _service.GetServiceRequestById(Id);
                return service != null ? Ok(service) : NotFound("No Service Request Found!!");

            }
            catch (Exception ex) { throw new Exception($"Error While Fetching Details:{ex.Message}"); }

        }
        [HttpPost("AddServiceRequest")]
        public async Task<IActionResult> AddService([FromBody] CreateServiceResquestDTO create)
        {
            try 
            {
                var service = await _service.CreateRequest(create);
                if (service != null)
                {
                    return Ok(service);
                }
                else { return NotFound("Unable To Add Service Request"); }
            }
            catch (Exception ex) { throw new Exception($"Error While Fetching Details:{ex.Message}"); }
        }
        [HttpPut("UpdateServiceRequest/{Id:int}")]
        public async Task<IActionResult> UpdateService([FromBody] UpdateServiceRequestDTO update,int Id)
        {
            try
            {
                var service = await _service.UpdateRequest(update,Id);
                if (service != null)
                {
                    return Ok(service);
                }
                else { return NotFound("Unable To Update Service!!"); }
            }
            catch (Exception ex) { throw new Exception($"Error While Fetching Details:{ex.Message}"); }
        }
        [HttpDelete("DeleteServiceRequest/{Id:int}")]
        public async Task<IActionResult> DeleteRequest(int Id)
        {
            try
            {
                var service = await _service.DeleteRequest(Id);
                if(service != null)
                {
                    return Ok(service);
                }
                return NotFound("User With ID NotFound!!");

            }
            catch (Exception ex) { throw new Exception($"Error While Fetching Details:{ex.Message}"); }
        }
    }
}
