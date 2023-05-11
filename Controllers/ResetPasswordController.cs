using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ResetPasswordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
