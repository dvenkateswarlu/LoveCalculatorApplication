namespace LoveCalculatorApp.Services
{
    public interface IEmailService
    {
        void SendMail(string userName, string userEmail, string result);
    }
}