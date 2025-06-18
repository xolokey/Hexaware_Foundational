//using AssertManagementAPI.Authentication;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace AssertManagementWebApp.Model
{
    public class User
    {
        public int UserId { get; set; }
        public required string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        public required string Role { get; set; }
        [DataType(DataType.PhoneNumber)]
        public required string ContactNumber { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; }
    }

}
