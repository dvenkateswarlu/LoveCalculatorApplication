using System.ComponentModel.DataAnnotations;

namespace LoveCalculatorApp.EmailDTO
{
    public class EmaiLDTO
    {
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string? Email { get; set; }

        public override string ToString()
        {
            return $"EmaiLDTO [Email={Email}]";
        }
    }
}