using System.ComponentModel.DataAnnotations;
using LoveCalculatorApp.CommunicationDTO;
using LoveCalculatorApp.Validators;

namespace LoveCalculatorApp.UserDTO
{
    public class RegisterDTO
    {
        public string? Name { get; set; }

        [Required(ErrorMessage = "Enter your user name")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter the password")]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must be at least 8 chars, have upper, lower, digit and special char"
        )]
        public string Password { get; set; } = string.Empty;

        public string? Country { get; set; }

        [Required(ErrorMessage = "Enter your gender")]
        public string Gender { get; set; } = string.Empty;

        [Age(18, 50)]
        public int? Age { get; set; }

        public CommunicateDTO Communicationdto { get; set; } = new CommunicateDTO();


        public override string ToString()
        {
            return $"RegisterDTO [Name={Name}, Username={Username}, Password={Password}, Country={Country}, Gender={Gender}, Age={Age}, Communicationdto={Communicationdto}]";
        }
    }
}