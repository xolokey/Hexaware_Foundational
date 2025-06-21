using AssertManagementAPI.Context;
using AssertManagementAPI.DTO.User;
using AssertManagementAPI.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
        public async Task<string> AddUser(CreateUserDTO userDTO)
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
                    };
                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();
                    return "....User Added SuccessFully....";
                }
                else
                {
                    return "Enter All The Product Details!!";
                }

            }
            catch (Exception ex) { throw new Exception($"Error in AddUser{ex.Message}"); }
        }
        //Delete User
        public async Task<string> DeleteUser(int id)
        {
            try
            {
                var user = await _context.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();
                if (user != null)
                {
                    user.IsActive = false;
                    await _context.SaveChangesAsync();
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
        public async Task<string> UpdateUser(int id, UpdateUserDTO userDTO)
        {
            try
            {
                var user = await _context.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();
                if (user != null)
                {
                    user.Name = userDTO.Name;
                    user.Email = userDTO.Email;
                    user.ContactNumber = userDTO.ContactNumber;
                    user.Address = userDTO.Address;
                    user.IsActive = userDTO.IsActive;
                    await _context.SaveChangesAsync();
                    return $"....User With {id} Updated Succesfully....";
                }
                else
                    return $"User With {id} Not Found!!";
            }
            catch (Exception ex) { throw new Exception($"Exceptions While Updating User {ex.Message}"); }

        }
        public async Task<List<UserDTO>> GetAllUsers()
        {
            try
            {
                var users = await _context.Users.Where(u => u.IsActive)
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
                    .ToListAsync();
                return users;

            }
            catch (Exception ex) { throw new Exception($"Exception While Fetching All Users{ex.Message}"); }
        }
        public async Task<UserDTO> GetUserById(int id)
        {
            try
            {
                var user = await _context.Users.Where(u => u.UserId == id && u.IsActive).FirstOrDefaultAsync();
                if (user != null)
                {
                    return _mapper.Map<UserDTO>(user);
                }
                else
                    return null;

            }
            catch (Exception ex) { throw new Exception($"Error While Fetching User Details{ex.Message}"); }
        }
        public async Task<List<UserDTO>> GetUserByName(string name)
        {
            try
            {
                var users =  _context.Users.Where(u => u.Name == name && u.IsActive);
                if (users.Any())
                {
                    return await _mapper.ProjectTo<UserDTO>(users.AsQueryable()).ToListAsync();
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
        public async  Task<List<UserDTO>> SearchUserByRole(string role)
        {
            try
            {   
                if (!string.IsNullOrWhiteSpace(role))
                {
                    return await _context.Users
                        .Where(u => u.Role ==role && u.IsActive)
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
                        .ToListAsync();
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
