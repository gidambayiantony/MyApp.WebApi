using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging.Abstractions;


namespace MyApp.WebApi.DTO.Requests
{
    public class CreateAffiliateReq
    {
        [Required]
        [MaxLength(50)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string CountryCode { get; set; } = null!;

         

        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = null!;

        [Required]
      
        public string? UserName { get; set; }
        public string Phone { get; set; } = null!;
    }
}
