using AssertManagementAPI.Model;
using AssertManagementAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssertManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService) 
        {
            _userService = userService;
        }
        [HttpGet("AllUsers")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = _userService.GetAllUsers();
                if (users == null)
                {
                    return NotFound();
                }
                
                 return Ok(users);
            }
            catch (Exception ex)
            {

                throw new Exception($" Exception in GetAllUsers ${ex.Message}");
            }
        }

        [HttpGet("userbyid/{id:int}")]
        public async Task<IActionResult> GetProductsById(int id)
        {
            try
            {
                var users = _userService.GetUserById(id);
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {

                throw new Exception($" Exception in GetAllProducts ${ex.Message}");
            }
        }
        [HttpGet("searchbyname")]
        public async Task<IActionResult> GetUsersByName(string name)
        {
            try
            {
                var users = _userService.GetUserByName(name);
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {

                throw new Exception($" Exception in GetAllProducts ${ex.Message}");
            }
        }
        [HttpGet("searchbyrole")]
        public async Task<IActionResult> GetUsersByRole(string role)
        {
            try
            {
                var users = _userService.SearchUserByRole(role);
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {

                throw new Exception($" Exception in GetAllProducts ${ex.Message}");
            }
        }
        [HttpPost("addnewuser")]
        public async Task<IActionResult> CreateProduct(User user)
        {
            try
            {
                var users = _userService.AddUser(user);
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {

                throw new Exception($" Exception in GetAllProducts ${ex.Message}");
            }
        }

        [HttpPut("updateuser/{id:int}")]
        public async Task<IActionResult> CreateProduct(int id, User user)
        {
            try
            {
                var users = _userService.UpdateUser(id, user);
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {

                throw new Exception($" Exception in GetAllProducts ${ex.Message}");
            }
        }
        [HttpDelete("deleteuser/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var users = _userService.DeleteUser(id);
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {

                throw new Exception($" Exception in GetAllProducts ${ex.Message}");
            }
        }
    }
}
