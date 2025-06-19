using System.ComponentModel.DataAnnotations;

namespace AssertManagementAPI.Authentication.AuthDTO
{
    public class RegisterDTO
    {
        public required string FullName { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
}
