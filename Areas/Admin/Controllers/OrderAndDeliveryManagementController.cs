using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebApp.Areas.Admin.Controllers
{
    public class OrderAndDeliveryManagementController : Controller
    {
        [Area("Admin")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
