using AssertManagementAPI.DTO.User;
using AssertManagementAPI.Model;

namespace AssertManagementAPI.Repository
{
    public interface IUserService
    {
        public List<UserDTO> GetAllUsers();
        public UserDTO GetUserById(int id);
        public List<UserDTO> GetUserByName(string name);
        public List<UserDTO> SearchUserByRole(string role);
        public string AddUser(CreateUserDTO userDTO);
        public string UpdateUser(int id, UpdateUserDTO userDTO);
        public string DeleteUser(int id);
    }
}
