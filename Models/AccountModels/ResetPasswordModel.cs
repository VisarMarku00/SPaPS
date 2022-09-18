using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SPaPS.Models.AccountModels
{
    public class ResetPasswordModel
    {
        public string Email { get; set; } =  string.Empty;
        public string Token { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;

        [NotMapped]
        [Required(ErrorMessage = "Confirm Password required")]
        [Compare("NewPassword", ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
