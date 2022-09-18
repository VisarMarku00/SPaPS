using System.ComponentModel;

namespace SPaPS.Models.AccountModels
{
    public class LoginModel
    {
        [DisplayName("User name")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
