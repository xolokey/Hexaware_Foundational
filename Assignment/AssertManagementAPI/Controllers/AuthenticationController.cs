using AssertManagementAPI.Authentication.AuthDTO;
using AssertManagementAPI.Authentication.AuthServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var result = await _authService.RegisterAsync(dto);
            return Ok(new { message = result });
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var token = await _authService.LoginAsync(dto);
            if (string.IsNullOrEmpty(token))
                return Unauthorized(new { message = "Invalid username or password" });

            return Ok(new { token });
        }

        // POST: api/auth/forgot-password
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDTO dto)
        {
            var result = await _authService.GenerateResetTokenAsync(dto);
            return Ok(new { message = result });
        }

        // POST: api/auth/reset-password
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO dto)
        {
            var result = await _authService.ResetPasswordAsync(dto);
            return Ok(new { message = result });
        }

        // GET: api/auth/secured
        [Authorize]
        [HttpGet("secured")]
        public IActionResult SecuredTest()
        {
            return Ok(new { message = "You are authorized!" });
        }
    }
}
