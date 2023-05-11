using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class LockoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
