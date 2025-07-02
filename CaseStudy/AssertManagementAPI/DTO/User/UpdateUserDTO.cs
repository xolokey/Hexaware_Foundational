using System.ComponentModel.DataAnnotations;

namespace AssertManagementAPI.DTO.User
{
    public class UpdateUserDTO
    {
        public required string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }
        public required string ContactNumber { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; }
    }
}
