using Microsoft.AspNetCore.Mvc;
using LoveCalculatorApp.Services;
using LoveCalculatorApp.UserDTO;
using LoveCalculatorApp.Models;
using Microsoft.AspNetCore.Http;

namespace LoveCalculatorApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserService _userService;

        public LoginController(UserService userService)
        {
            _userService = userService;
        }

        // GET: /
        [HttpGet("/")]
        public IActionResult Index()
        {
            return View(new LoginPage());
        }

        // POST: /Login
        [HttpPost]
        public IActionResult Login(LoginPage loginpage)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", loginpage);
            }

            var user = _userService.Authenticate(loginpage.Email, loginpage.Password);

            if (user != null)
            {
                // ✅ Store session (optional)
                HttpContext.Session.SetString("UserEmail", user.Email);

                // Redirect to Home
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Invalid username or password!";
                return View("Index", loginpage);
            }
        }
    }
}