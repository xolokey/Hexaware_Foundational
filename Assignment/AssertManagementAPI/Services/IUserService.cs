using AssertManagementAPI.DTO.User;
using AssertManagementAPI.Model;

namespace AssertManagementAPI.Repository
{
    public interface IUserService
    {
        public Task<List<UserDTO>> GetAllUsers();
        public Task<UserDTO> GetUserById(int id);
        public Task<List<UserDTO>> GetUserByName(string name);
        public Task<List<UserDTO>> SearchUserByRole(string role);
        public Task<string> AddUser(CreateUserDTO userDTO);
        public Task<string> UpdateUser(int id, UpdateUserDTO userDTO);
        public Task<string> DeleteUser(int id);
    }
}
