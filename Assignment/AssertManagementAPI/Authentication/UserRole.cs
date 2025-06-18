using AssertManagementAPI.Model;
namespace AssertManagementAPI.Authentication
{
    public class UserRole
    {
        public const string Admin = "Admin";
        public const string User= "User";

        public ICollection <User>? users {  get; set; }
    }
}
