using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.Models.ViewModel;
using WebApp.Services;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["CurrentPage"] = "Quản Lý Sản Phẩm";
            var product = from _sp in _context.Proudct
                          where _sp.IsDeleted == false
                          select new ProductViewModel
                          {
                              Id = _sp.Id,
                              Name = _sp.Name,
                              Description = _sp.Description,
                              Slug = _sp.Slug,
                              Quantity = _sp.Quantity,
                              HotSale = _sp.HotSale,
                              HotTrend = _sp.HotTrend,
                              Img1 = _sp.Img1,
                              Img2 = _sp.Img2,
                              Img3 = _sp.Img3,
                              Price = _sp.Price,
                              ProductCode = _sp.ProductCode,
                              CategoryName = _context.Category.FirstOrDefault(i => i.Id == _sp.CategoryId)!.Name ?? "",
                              BrandName = _context.Brand.FirstOrDefault(i => i.Id == _sp.BrandId)!.BrandName ?? "",
                          };

            ViewBag.Product = product.ToList();

            return View();
        }
    }
}
