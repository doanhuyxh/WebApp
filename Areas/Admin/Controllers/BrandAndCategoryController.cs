using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class BrandAndCategoryController : Controller
    {
        public IActionResult IndexCategory()
        {
            ViewData["CurrentPage"] = "Loại sản phẩm";
            return View();
        }
        public IActionResult IndexBrand()
        {
            ViewData["CurrentPage"] = "Thương hiệu";
            return View();
        }
    }
}
