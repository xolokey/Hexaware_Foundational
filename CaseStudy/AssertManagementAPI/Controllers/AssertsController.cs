using AssertManagementAPI.DTO.Assert;
using AssertManagementAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssertManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssertsController : ControllerBase
    {
        private readonly IAssertService _assertService;
        public AssertsController(IAssertService assertService)
        {
            _assertService = assertService;
        }
        [HttpGet("AllAssert")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var asserts = await _assertService.AllAssert();
                return asserts == null || !asserts.Any() ? NotFound("No Assert Found!!") : Ok(asserts);

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        [HttpGet("AssertById/{Id:int}")]
        public async Task<IActionResult> GetId(int Id)
        {
            try
            {
                var assert = await _assertService.AssertById(Id);
                return assert == null ? NotFound($"No Assert with ID:{Id} Found!!") : Ok(assert);

            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
        [HttpGet("AssertByName")]
        public async Task<IActionResult> GetByName([FromQuery]string name)
        {
            try
            {
                var assert = await _assertService.AssertByName(name);
                return assert != null ? Ok(assert) : NotFound($"Assert with Name:{name} Not Found!!");

            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
        [HttpGet("AssertByStatus")]
        public async Task<IActionResult> GetByStatus([FromQuery]string status)
        {
            try
            {
                var assert = await _assertService.AssertByStatus(status);
                return assert != null ? Ok(assert) : NotFound($"No Asset With Status:{status} Found!!");
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        [HttpGet("AssertByAssertNo")]
        public async Task<IActionResult> GetByAssertN0([FromQuery]string assertNo)
        {
            try
            {
                var asert = await _assertService.AssertByAssertNo(assertNo);
                return asert != null ? Ok(asert) : NotFound($"No Assert with AssertNo:{assertNo} Found!!");


            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        [HttpPost("AddAssert")]
        public async Task<IActionResult> Add([FromBody] CreateAssertDTO assertDTO)
        {
            try
            { 
                var assert = await _assertService.Create(assertDTO);
                if(assertDTO != null)
                {
                    return Ok(assert);
                }
                return NotFound();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        [HttpDelete("DeleteAssert/{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var user = await _assertService.Delete(Id);
                if(user == null)
                {
                    return NotFound();
                }
                return Ok(user);

            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
        [HttpPut("UpdateAssert/{Id:int}")]
        public async Task<IActionResult> Update([FromBody]UpdateAssertDTO assertDTO, int Id)
        {
            try
            {
                var user = await _assertService.Update(assertDTO, Id);
                if(user != null)
                {
                    return Ok(user);
                }
                return NotFound();

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        } 
            
    }
}
