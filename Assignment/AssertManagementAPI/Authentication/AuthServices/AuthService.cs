using AssertManagementAPI.Authentication;
using AssertManagementAPI.Context;
using AssertManagementAPI.Model;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using AssertManagementAPI.Authentication.AuthDTO;

namespace AssertManagementAPI.Authentication.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly JwtHelper _jwt;
        private readonly IEmailService _email;
        public AuthService(AppDbContext db, JwtHelper jwt, IEmailService email)
        {
            _db = db;
            _jwt = jwt;
            _email = email;
        }

        public async Task<string> RegisterAsync(RegisterDTO dto)
        {
            if (await _db.Users.AnyAsync(u => u.Email == dto.Email))
                return "User already exists";

            var user = new User
            {
                Name = dto.FullName,
                Email = dto.Email,
                Role = dto.Role,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                ContactNumber = "N/A" 
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return "Registration successful";
        }

        public async Task<string?> LoginAsync(LoginDTO dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (!string.IsNullOrEmpty(user.Password) && user.Password == dto.Password)
            {
                return _jwt.GenerateToken(user);
            }
            else if(!string.IsNullOrEmpty(user.Password))
            {
                if (BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                    return _jwt.GenerateToken(user);
            }
            

            return null;
        }
        public async Task<string> GenerateResetTokenAsync(ForgotPasswordDTO dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null) return "Email not registered";

            user.ResetPasswordToken = Guid.NewGuid().ToString();
            user.ResetTokenExpiry = DateTime.Now.AddMinutes(15);

            await _db.SaveChangesAsync();
            //return user.ResetPasswordToken!;
            await _email.SendEmailAsync(user.Email, "Password Reset Request",
                $"Use this token to reset your password: <b>{user.ResetPasswordToken}</b><br/>" +
                $"This token will expire at {user.ResetTokenExpiry?.ToLocalTime()}."
                
            );
            return "Reset token sent to your email";
        }

        public async Task<string> ResetPasswordAsync(ResetPasswordDTO dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u =>
                u.ResetPasswordToken == dto.Token && u.ResetTokenExpiry > DateTime.Now);

            if (user == null)
                return "Invalid or expired token";

            user.Password = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            user.ResetPasswordToken = null;
            user.ResetTokenExpiry = null;

            await _db.SaveChangesAsync();
            return "Password reset successful";
        }

    }

}
