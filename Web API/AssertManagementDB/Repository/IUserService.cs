using AssertManagementDB.Models;
namespace AssertManagementDB.Repository
{
    public interface IUserService
    {
        public List<User> GetUsers();
        public User GetUserById(int id);
        public User AddUser(User user);
        public string UpdateUser(User user,int id);
  
        public string DeleteUser(int id);

    }
}
