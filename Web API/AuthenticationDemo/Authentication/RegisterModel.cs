
using System.ComponentModel.DataAnnotations;

namespace AuthenticationDemo.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="User Name Can t be Empty!!")]
        public string  UserName {  get; set; }
        [Required(ErrorMessage ="Password cant be empty!!")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Email cant be empty")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Role May be Admin|User")]
        public string Role { get; set; }
    }
}
