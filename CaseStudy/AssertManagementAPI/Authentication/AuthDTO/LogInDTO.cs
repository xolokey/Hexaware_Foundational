using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AssertManagementAPI.Authentication.AuthDTO
{
    public class LoginDTO
    {
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
