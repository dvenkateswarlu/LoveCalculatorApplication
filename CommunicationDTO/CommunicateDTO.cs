using System.ComponentModel.DataAnnotations;

namespace LoveCalculatorApp.CommunicationDTO
{
    public class CommunicateDTO
    {
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string? Email { get; set; }

        public Phone? Phone { get; set; } = new Phone();

        public override string ToString()
        {
            return $"CommunicateDTO [Email={Email}, Phone={Phone}]";
        }
    }
}