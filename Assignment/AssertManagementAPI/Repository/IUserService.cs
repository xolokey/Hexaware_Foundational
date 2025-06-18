using AssertManagementAPI.Model;

namespace AssertManagementAPI.Repository
{
    public interface IUserService
    {
        public List<User> GetAllUsers();
        public User GetUserById(int id);
        public List<User> GetUserByName(string name);
        public List<User> SearchUserByRole(string role);
        public string AddUser(User user);
        public string UpdateUser(int id, User user);
        public string DeleteUser(int id);
    }
}
