namespace LoveCalculatorApp.CommunicationDTO
{
    public class Phone
    {
        public string? CountryCode { get; set; }
        public string? UserNumber { get; set; }

        public override string ToString()
        {
            return $"{CountryCode}-{UserNumber}";
        }
    }
}