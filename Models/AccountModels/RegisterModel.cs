using System.ComponentModel.DataAnnotations;

namespace SPaPS.Models.AccountModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email required")]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone number required")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Client type required")]
        [Display(Name = "Client Type")]
        public int ClientTypeId { get; set; }

        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Address required")]
        public string Address { get; set; } = null!;

        [Required]
        [Display(Name = "Id")]
        public string IdNo { get; set; } = null!;

        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Country required")]
        [Display(Name = "Country")]
        public int? CountryId { get; set; }

        public string Role { get; set; }
    }
}
