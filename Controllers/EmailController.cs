using Microsoft.AspNetCore.Mvc;
using LoveCalculatorApp.EmailDTO;
using LoveCalculatorApp.Services;
using LoveCalculatorApp.UserDTO;
using Microsoft.AspNetCore.Http;

namespace LoveCalculatorApp.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        // GET: /Email
        public IActionResult Index()
        {
            return View(new EmaiLDTO());
        }

        // POST: /Email/Send
        [HttpPost]
        public IActionResult Send(EmaiLDTO emaildto)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", emaildto);
            }

            // 🔁 Get session data (equivalent to @SessionAttribute)
            var username = HttpContext.Session.GetString("Username");
            var result = HttpContext.Session.GetString("Result");

            if (username == null || result == null)
            {
                return RedirectToAction("Index", "Home");
            }

            _emailService.SendMail(username, emaildto.Email!, result);

            return View("Result", emaildto);
        }
    }
}