using AssertManagementAPI.Context;
using AssertManagementAPI.DTO.User;
using AssertManagementAPI.Model;
using AutoMapper;

namespace AssertManagementAPI.Repository
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //To Add User
        public string AddUser(CreateUserDTO userDTO)
        {
            try
            {
                if (userDTO != null)
                {
                    var user = new User
                    {
                        Name = userDTO.Name,
                        Email = userDTO.Email,
                        Password = userDTO.Password,
                        Role = userDTO.Role,
                        ContactNumber = userDTO.ContactNumber,
                        Address = userDTO.Address,
                        IsActive = userDTO.IsActive,
                    };
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return "....Product Added SuccessFully....";
                }
                else
                {
                    return "Enter All The Product Details!!";
                }

            }
            catch (Exception ex) { throw new Exception($"Error in AddUser{ex.Message}"); }
        }
        public string DeleteUser(int id)
        {
            try
            {
                var user = _context.Users.Where(u => u.UserId == id).FirstOrDefault();
                if (user != null)
                {
                    user.IsActive = false;
                    _context.SaveChanges();
                    return "....User Deleted Succesfully....";
                }
                else
                    return "User Not Found!!";
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception while deleting User{ex.Message}");
            }
        }
        public string UpdateUser(int id, UpdateUserDTO userDTO)
        {
            try
            {
                var user = _context.Users.Where(u => u.UserId == id).FirstOrDefault();
                if (user != null)
                {
                    user.Name = userDTO.Name;
                    user.Email = userDTO.Email;
                    user.ContactNumber = userDTO.ContactNumber;
                    user.Address = userDTO.Address;
                    user.IsActive = userDTO.IsActive;
                    _context.SaveChanges();
                    return $"....User With {id} Updated Succesfully....";
                }
                else
                    return $"User With {id} Not Found!!";
            }
            catch (Exception ex) { throw new Exception($"Exceptions While Updating User {ex.Message}"); }

        }
        public List<UserDTO> GetAllUsers()
        {
            try
            {
                var users = _context.Users.Where(u => u.IsActive)
                    .Select(u => new UserDTO
                    {
                        UserId = u.UserId,
                        Name = u.Name,
                        Email = u.Email,
                        Password = u.Password,
                        Role = u.Role,
                        ContactNumber = u.ContactNumber,
                        Address = u.Address,
                        IsActive = u.IsActive,
                    })
                    .ToList();
                return users;

            }
            catch (Exception ex) { throw new Exception($"Exception While Fetching All Users{ex.Message}"); }
        }
        public UserDTO GetUserById(int id)
        {
            try
            {
                var user = _context.Users.Where(u => u.UserId == id && u.IsActive).FirstOrDefault();
                if (user != null)
                {
                    return _mapper.Map<UserDTO>(user);
                }
                else
                    return null;

            }
            catch (Exception ex) { throw new Exception($"Error While Fetching User Details{ex.Message}"); }
        }
        public List<UserDTO> GetUserByName(string name)
        {
            try
            {
                var users = _context.Users.Where(u => u.Name == name && u.IsActive);
                if (users.Any())
                {
                    return _mapper.ProjectTo<UserDTO>(users.AsQueryable()).ToList();
                }
                else
                {
                    return new List<UserDTO>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error While Fetching User: {ex.Message}");
            }
        }
        public List<UserDTO> SearchUserByRole(string role)
        {
            try
            {   
                if (!string.IsNullOrWhiteSpace(role))
                {
                    return _context.Users
                        .Where(u => u.Role.Contains(role, StringComparison.OrdinalIgnoreCase) && u.IsActive)
                        .Select(u => new UserDTO
                        {
                            UserId = u.UserId,
                            Name = u.Name,
                            Email = u.Email,
                            Password = u.Password,
                            ContactNumber = u.ContactNumber,
                            Address = u.Address,
                            Role = u.Role,
                            IsActive = u.IsActive
                        })
                        .ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while Fetching Role!!:{ex.Message}");
            }
        }
    }
}
