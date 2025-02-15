using System.ComponentModel.DataAnnotations;

namespace Restino.App.ViewModels
{
    public class RegistrationRequest
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\W).*$", ErrorMessage = "Password must contain at least one uppercase letter and one special character.")]
        public string Password { get; set; } = string.Empty;
    }
}
