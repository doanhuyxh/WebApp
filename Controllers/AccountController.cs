using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login() { return View(); }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register() { return View(); }
    }
}
