using AssertManagementAPI.DTO.User;
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
                return users == null || !users.Any() ? NotFound("No users Found") : Ok(users);
                
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
                return users == null ? NotFound($"User with ID:{id} Not Found!"):Ok(users);
            }
            catch (Exception ex)
            {

                throw new Exception($" Exception in GetAllProducts ${ex.Message}");
            }
        }
        [HttpGet("searchbyname")]
        public async Task<IActionResult> GetUsersByName([FromQuery]string name)
        {
            try
            {
                var users = _userService.GetUserByName(name);
                return users == null || !users.Any() ? NotFound($"User With Name:{name} Not Found!!") : Ok(users);
            }
            catch (Exception ex)
            {

                throw new Exception($" Exception in GetAllProducts ${ex.Message}");
            }
        }
        [HttpGet("searchbyrole")]
        public async Task<IActionResult> GetUsersByRole([FromQuery]string role)
        {
            try
            {
                var users = _userService.SearchUserByRole(role);
                return users == null || !users.Any() ? NotFound($"No users with Role:{role} Found!!") : Ok(users);
            }
            catch (Exception ex)
            {

                throw new Exception($" Exception in GetAllProducts ${ex.Message}");
            }
        }
        [HttpPost("addnewuser")]
        public async Task<IActionResult> CreateProduct([FromBody]CreateUserDTO userDTO)
        {
            try
            {
                var users = _userService.AddUser(userDTO);
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
        public async Task<IActionResult> UpdateUser(int id,[FromBody] UpdateUserDTO user)
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
