using System.ComponentModel.DataAnnotations;

namespace AssertManagementAPI.Authentication.AuthDTO
{
    public class ForgotPasswordDTO
    {
        [EmailAddress]
        public required string Email { get; set; }
    }

}
