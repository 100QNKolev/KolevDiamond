using System.ComponentModel.DataAnnotations;

namespace KolevDiamond.Models.Auth
{
    public class LoginRequestModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
