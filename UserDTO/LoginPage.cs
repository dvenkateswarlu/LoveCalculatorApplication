using System.ComponentModel.DataAnnotations;

namespace LoveCalculatorApp.UserDTO
{
    public class LoginPage
    {
        [Required(ErrorMessage = "Enter the email")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter the password")]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must be at least 8 chars, have upper, lower, digit and special char"
        )]
        public string Password { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"LoginPage [Email={Email}]";
        }
    }
}