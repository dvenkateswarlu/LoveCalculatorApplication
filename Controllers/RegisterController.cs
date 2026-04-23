using Microsoft.AspNetCore.Mvc;
using LoveCalculatorApp.Data;
using LoveCalculatorApp.Models;
using LoveCalculatorApp.UserDTO;

namespace LoveCalculatorApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Register
        public IActionResult Index()
        {
            return View(new RegisterDTO());
        }

        // POST: /Register/Register
        [HttpPost]
        public IActionResult Register(RegisterDTO registerdto)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", registerdto);
            }

            var user = new UserEntity
            {
                Username = registerdto.Username,
                Password = registerdto.Password,
                Email = registerdto.Communicationdto.Email
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return View("Result", registerdto);
        }
    }
}