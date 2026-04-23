using LoveCalculatorApp.Data;
using LoveCalculatorApp.Models;

namespace LoveCalculatorApp.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public UserEntity? Authenticate(string email, string password)
        {
            return _context.Users
                .FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}