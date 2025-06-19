using System.ComponentModel.DataAnnotations;

namespace AssertManagementAPI.Authentication.AuthDTO
{
    public class ResetPasswordDTO
    {
        public required string Token { get; set; }
        public required string NewPassword { get; set; }
    }

}
