using AssertManagementDB.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AssertManagementDB.Models;

namespace AssertManagementDB.Controllers
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
        //To Add User
        [HttpPost("AddUser")]
        public IActionResult AddUser(User user)
        {
            try
            {
                if (user != null)
                {
                    _userService.AddUser(user);
                    return Ok($"User With UserId:{user.UserId} Added Successfully!!!");
                }
                return NotFound("Some thing Gone Wrong!!");

            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
        //To Update User
        [HttpPut("UpdateUser/{id:int}")]
        public IActionResult UpdateUser(User user, int id)
        {
            try
            {
                var Users = _userService.UpdateUser(user, id);
                return Ok($"User With UserId:{user.UserId} Updated Successfully");

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //To Delete User
        [HttpDelete("DeleteUser/{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                if(id > 0)
                {
                    _userService.DeleteUser(id);
                    return Ok($"User With UserId{id} Deleted Successfully!!");
                }
                return NotFound();

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //To get All Users
        [HttpGet("AllUser")]
        public IActionResult AllUsers()
        {
            try
            {
                var users = _userService.GetUsers();
                if (users != null)
                {
                    
                    return Ok(users);
                }
                return NotFound("No User Found!!...");



            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
