
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace AssertManagementAPI.Model
{
    public class User
    {
        [Key]
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
        public string? ResetPasswordToken { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ResetTokenExpiry { get; set; }

    }

}
