using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models.ViewModel;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class BrandAndCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BrandAndCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult IndexCategory()
        {
            ViewData["CurrentPage"] = "Loại sản phẩm";
            return View();
        }
        public IActionResult IndexBrand()
        {
            ViewData["CurrentPage"] = "Thương hiệu";

            var DS = from br in _context.Brand
                     where br.IsDeleted == false
                     select new BrandViewModel
                     {
                         Id = br.Id,
                         BrandName = br.BrandName,
                         BrandImgLogo = br.BrandImgLogo,
                         BrandDescription = br.BrandDescription,
                         CreatedBy = br.CreatedBy,
                         CreatedDate = br.CreatedDate,
                     };
            ViewBag.Brand = DS.ToList();

            return View();
        }

        public IActionResult AddEditBrand()
        {
            BrandViewModel model = new BrandViewModel();
            return PartialView("_AddEditBrand", model);
        }
    }
}
