using AssertManagementWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AssertManagementWebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserServices _services;
        public UsersController(UserServices services)
        {
            _services = services;
        }
        public async Task<IActionResult> Index(string searchUser)
        {
            var users = string.IsNullOrEmpty(searchUser)
                ? await _services.GetUsers() : await _services.GetUserByName(searchUser);
            ViewBag.SearchUser = searchUser;
            return View(users);
        }

    }
}
