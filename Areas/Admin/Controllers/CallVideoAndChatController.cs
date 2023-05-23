using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CallVideoAndChatController : Controller
    {
        public IActionResult Index()
        {
            ViewData["CurrentPage"] = "Video Call";
            return View();
        }
    }
}
