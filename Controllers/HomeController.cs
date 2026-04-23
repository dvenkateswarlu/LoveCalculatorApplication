using Microsoft.AspNetCore.Mvc;
using LoveCalculatorApp.Services;
using LoveCalculatorApp.UserDTO;

namespace LoveCalculatorApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoveCalculatorService _logic;

        public HomeController(ILoveCalculatorService logic)
        {
            _logic = logic;
        }

        // GET: /Home or /Home/Index
        [HttpGet]
        public IActionResult Index()
        {
            return View(new HomePage());
        }

        // POST: /Home/Calculate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calculate(HomePage homepage)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", homepage);
            }

            // Call FLAMES logic
            string appResult = _logic.CalculateLove(homepage.Username, homepage.Crushname);
            homepage.Result = appResult;

            // Store in session
            HttpContext.Session.SetString("Username", homepage.Username);
            HttpContext.Session.SetString("Result", homepage.Result);

            return View("Result", homepage);
        }
    }
}
