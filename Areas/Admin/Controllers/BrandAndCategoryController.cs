using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;
using WebApp.Data;
using WebApp.Models;
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
        [HttpPost]
        public async Task<IActionResult> AddEditBrand(BrandViewModel vm)
        {
            JsonResultViewModel jsonResultViewModel = new JsonResultViewModel();
            if (ModelState.IsValid)
            {
                Brand brand = new Brand();
                if (vm.Id == 0)
                {
                    brand = vm;
                    brand.CreatedBy = HttpContext.User.Identity.Name ?? "";
                    brand.CreatedDate = DateTime.Now;
                    await _context.AddAsync(brand);
                    await _context.SaveChangesAsync();
                    jsonResultViewModel.Object = brand;
                    jsonResultViewModel.Success = true;
                    jsonResultViewModel.Mesaage = "Đã tạo thành công";
                    return Json(jsonResultViewModel);
                }
                else
                {
                    brand = await _context.Brand.FindAsync(vm.Id);
                    _context.Entry(brand).CurrentValues.SetValues(vm);
                    await _context.SaveChangesAsync();
                    jsonResultViewModel.Object = brand;
                    jsonResultViewModel.Success = true;
                    jsonResultViewModel.Mesaage = "Đã cập nhật thành công";
                    return Json(jsonResultViewModel);
                }

            }
            jsonResultViewModel.Object = null;
            jsonResultViewModel.Success = false;
            jsonResultViewModel.Mesaage = "Tạo thất bại";
            return Json(jsonResultViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            JsonResultViewModel jsonResultViewModel = new JsonResultViewModel();
            jsonResultViewModel.Success = false;
            jsonResultViewModel.Mesaage = "Xóa thất bại";
            jsonResultViewModel.Object = null;
            try
            {
                var brand = await _context.Brand.FindAsync(id);
                brand.IsDeleted = true;
                _context.Update(brand);
                await _context.SaveChangesAsync();
                jsonResultViewModel.Object = brand;
                jsonResultViewModel.Success = true;
                return Json(jsonResultViewModel);
            }
            catch (Exception ex) { }
            {
                return Json(jsonResultViewModel);
            }
        }
        [HttpGet]
        public IActionResult EditBrand(int id)
        {
            BrandViewModel model = new BrandViewModel();
            model = _context.Brand.FirstOrDefault(item => item.Id == id);
            return PartialView("_AddEditBrand", model);
        }


        public IActionResult IndexCategory()
        {
            ViewData["CurrentPage"] = "Loại sản phẩm";

            var DS = from cate in _context.Category
                     where cate.IsDeleted == false
                     select new CategoryViewModel
                     {
                         Id = cate.Id,
                         Name = cate.Name,
                         ParentName = _context.Category.FirstOrDefault(item => item.ParentId == cate.Id)!.Name ?? " ",
                         CreatedBy = cate.CreatedBy,
                         CreatedDate = cate.CreatedDate,
                     };
            ViewBag.Brand = DS.ToList();

            return View();
        }

        public IActionResult AddCategory()
        {
            CategoryViewModel model = new CategoryViewModel();
            return PartialView("_AddEditCategory", model);
        }
    }
}
