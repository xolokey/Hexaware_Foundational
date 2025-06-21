
using AssertManagementAPI.DTO.AssertCategory;
using AssertManagementAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssertManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssertCategoriesController : ControllerBase
    {
        private readonly IAssertCategoryService _service;
        public AssertCategoriesController(IAssertCategoryService service)
        {
            _service = service;
        }
        [HttpGet("AllCategories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var category = await _service.GetAllCategory();
                return category != null ? Ok(category) : NotFound("No Categories Avilable!!");

            }
            catch (Exception ex) { throw new Exception($"Error While Fetching Details:{ex.Message}"); }
        }
        [HttpGet("CategoryById/{Id:int}")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                var category = await _service.GetCategoryById(Id);
                return category != null ? Ok(category) : NotFound("No Category With the ID Avilable");

            }
            catch (Exception ex) { throw new Exception($"Error While Fetching Details{ex.Message}"); }
        }
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody]CreateAssertCategoryDTO dto)
        {
            try
            {
                if (dto != null) 
                {
                    var newcategory = await _service.CreateCategory(dto);
                    return Ok(newcategory);
                }
                else { return NotFound("Provide Required Details to Create a Category!!"); }

            }
            catch (Exception ex) { throw new Exception($"Error While Creating Details{ex.Message}"); }
        }
        [HttpPut("UpdateCategory/{Id:int}")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateAssertCategoryDTO dto, int Id)
        {
            try
            {
                if (dto != null)
                {
                    var updatedcategory = await _service.UpdateCategory(dto, Id);
                    return Ok(updatedcategory);
                }
                else { return NotFound(); }
            }
            catch (Exception ex) { throw new Exception($"Error While Creating Details{ex.Message}"); }
        }
        [HttpDelete("DeleteCategory/{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var category = await _service.DeleteCategory(Id);
                return category != null ? Ok(category) : NotFound("No Category With ID Found!!");


            }
            catch (Exception ex) { throw new Exception($"Error While Deleting Details{ex.Message}"); }
        }
    }
}
