using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ExternalLoginsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
