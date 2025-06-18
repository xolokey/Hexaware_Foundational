
using AssertManagementWebApp.Model;

namespace AssertManagementWebApp.Services
{
    public class UserServices
    {
        readonly HttpClient _httpClient;
        public UserServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetUsers() =>
            await _httpClient.GetFromJsonAsync<List<User>>("api/Users/AllUsers");
        public async Task<User> GetUserById(int id) =>
            await _httpClient.GetFromJsonAsync<User>($"api/Users/userbyid/{id}");
        public async Task<List<User>> GetUserByName(string name) =>
            await _httpClient.GetFromJsonAsync<List<User>>($"api/Users/searchbyname?name={name}");
        public async Task<User> GetUserByRole(string role) =>
            await _httpClient.GetFromJsonAsync<User>($"api/Users/searchbyrole?role={role}");
        public async Task CreateUser(User user)=>
            await _httpClient.PostAsJsonAsync<User>("api/Users/addnewuser",user);
        public async Task UpdateUser(int id, User user) =>
            await _httpClient.PutAsJsonAsync<User>($"api/Users/updateuser/{id}", user);
        public async Task DeleteUser(int id) =>
            await _httpClient.DeleteFromJsonAsync<User>($"api/Users/deleteuser/{id}");

    }
}
