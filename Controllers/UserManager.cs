using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class UserManager : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
