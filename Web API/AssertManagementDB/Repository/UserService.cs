using AssertManagementDB.Models;

namespace AssertManagementDB.Repository
{
    public class UserService:IUserService
    {
        //Creating an Connection
        private readonly AppDBContext _context;
        public UserService(AppDBContext context)
        {
            _context = context;
        }
        //To Add The User
        public User AddUser(User user)
        {
            try
            {
                if (user != null)
                { 
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return user;
                }
                return null;

            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
                
            }
        }
        //To Update User
        public string UpdateUser(User user,int id)
        {
            try
            {
                if (id == user.UserId) 
                {
                    var users = _context.Users.FirstOrDefault(u=> u.UserId == id);
                    if(users != null)
                    {
                        users.Name= user.Name;
                        users.Email = user.Email;
                        users.PasswordHash= user.PasswordHash;
                        users.ContactNumber= user.ContactNumber;
                        users.Address= user.Address;
                        _context.SaveChanges();
                        return $" User With UserId:{users.UserId} Updated Successfully!!";
                        
                    }
                    return $"User with {user.UserId} Not Found!!";
                }
                return "User Not Found!!";

            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }
        //To Delete a User
        public string DeleteUser(int Id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u=> u.UserId==Id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    return $"User With UserId:{user.UserId} Deleted !!";

                }
                return "User Not Found!!";

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Get User By Id
        public User GetUserById(int Id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u=> u.UserId==Id);
                if (user != null)
                {
                    return user;

                }
                return null;

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //Get All Users
        public List<User> GetUsers()
        {
            try
            {
                var users = _context.Users.ToList();
                if (users.Count > 0)
                {
                    return users;

                }
                return null;

            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }

    }

}
