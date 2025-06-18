using AssertManagementAPI.Context;
using AssertManagementAPI.Model;

namespace AssertManagementAPI.Repository
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            try
            {
                var users = _context.Users.ToList();
                if (users.Count > 0)
                    return users;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception While GetAllUsers ${ex.Message}");
            }
        }

        public List<User> GetUserByName(string name)
        {
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    var users = _context.Users.Where(p => !string.IsNullOrEmpty(p.Name) &&
                     p.Name.ToLower().Contains(name.ToLower())).ToList();
                    return users;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception($" Exception in GetUserByName ${ex.Message}");
            }
        }
        public List<User> SearchUserByRole(string role)
        {
            try
            {
                if (!string.IsNullOrEmpty(role))
                {
                    var users = _context.Users.Where(p => p.Role != null &&
                     p.Role.ToString().ToLower().Contains(role.ToLower())).ToList();
                    return users;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception($" Exception in SearchUserByRole ${ex.Message}");
            }
        }
        public User GetUserById(int id)
        {
            try
            {

                var product = _context.Users.FirstOrDefault(x => x.UserId == id);
                if (product != null)
                    return product;
                else
                    return null;

            }
            catch (Exception ex)
            {

                throw new Exception($"Exception in GetProductById ${ex.Message}");
            }
        }
        public string AddUser(User user)
        {
            try
            {
                if (user != null)
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return " User Added successfully";
                }
                else
                    return "Enter User details properly";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public string DeleteUser(int id)
        {
            try
            {
                var product = GetUserById(id);
                if (product != null)
                {
                    product.IsActive = false;
                }
                _context.SaveChanges();
                return "User Deleted successfully";

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public string UpdateUser(int id, User user)
        {
            try
            {
                var exisingUser = GetUserById(id);
                if (exisingUser == null)
                    return $"User With the Id {id} Not Found";
                exisingUser.Name = user.Name;
                exisingUser.Email = user.Email;
                exisingUser.ContactNumber = user.ContactNumber;
                exisingUser.Address = user.Address;
                exisingUser.IsActive = user.IsActive;
                _context.SaveChanges();

                return $"User with Id {id} is updated successfully";
            }
            catch (Exception ex)
            {

                throw new Exception($" Exception in UpdateUser ${ex.Message}");
            }
        }
    }

}
