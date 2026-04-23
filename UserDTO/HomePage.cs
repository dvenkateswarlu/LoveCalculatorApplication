using System.ComponentModel.DataAnnotations;

namespace LoveCalculatorApp.UserDTO
{
    public class HomePage
    {
        [Required(ErrorMessage = "Enter your name")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter your crush's name")]
        public string Crushname { get; set; } = string.Empty;

        public string? Result { get; set; }

        [MustBeTrue(ErrorMessage = "You must agree that this is for fun")]
        public bool TermsAndPrivacy { get; set; }

        public override string ToString()
        {
            return $"HomePage [Username={Username}, Crushname={Crushname}, Result={Result}, TermsAndPrivacy={TermsAndPrivacy}]";
        }
    }

    // Custom validation attribute for boolean "must be true"
    public class MustBeTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return value is bool b && b;
        }
    }
}
