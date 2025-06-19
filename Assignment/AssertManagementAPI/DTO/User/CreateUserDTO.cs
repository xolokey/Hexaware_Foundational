using System.ComponentModel.DataAnnotations;

namespace AssertManagementAPI.DTO.User
{
    public class CreateUserDTO
    {
        public required string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        public required string Role { get; set; } = "User";
        public required string ContactNumber { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; }
    }
}
