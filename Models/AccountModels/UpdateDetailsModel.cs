using System.ComponentModel.DataAnnotations;


namespace SPaPS.Models.AccountModels
{
    public class UpdateDetailsModel
    {
        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Client Type")]
        public int ClientTypeId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required]
        [Display(Name = "Id")]
        public string IdNo { get; set; } = null!;

        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int? CountryId { get; set; }
    }
}
