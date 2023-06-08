using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.Models.ViewModel;
using WebApp.Services;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICommon _icommon;

        public ProductController(ApplicationDbContext context, ICommon icommon)
        {
            _context = context;
            _icommon = icommon;
        }
        public IActionResult Index()
        {
            ViewData["CurrentPage"] = "Quản Lý Sản Phẩm";
            var product = from _sp in _context.Product
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
                              Stop = _sp.Stop,
                              CategoryName = _context.Category.FirstOrDefault(i => i.Id == _sp.CategoryId)!.Name ?? "",
                              BrandName = _context.Brand.FirstOrDefault(i => i.Id == _sp.BrandId)!.BrandName ?? "",
                          };

            ViewBag.Product = product.ToList();

            return View();
        }

        [HttpGet]
        public IActionResult AddEditProduct(int id)
        {
            List<ItemDropDown> itemCate = (from _l in _context.Category
                                           where _l.IsDeleted == false
                                           select new ItemDropDown { Id = _l.Id, Name = _l.Name, ParentId = _l.ParentId }).ToList();
            ViewBag.Cate = new SelectList(itemCate, "Id", "Name");

            List<ItemDropDown> itemBrand = (from _l in _context.Brand
                                            where _l.IsDeleted == false
                                            select new ItemDropDown { Id = _l.Id, Name = _l.BrandName }).ToList();
            ViewBag.Brand = new SelectList(itemBrand, "Id", "Name");

            ProductViewModel model = new ProductViewModel();
            if (id != 0)
            {
                model = _context.Product.FirstOrDefault(i => i.Id == id);
                return PartialView("_AddEditProduct", model);
            }
            else
            {
                return PartialView("_AddEditProduct", model);
            }
        }

        [HttpPost]
        public async Task<JsonResult> AddEditProduct(ProductViewModel model)
        {
            JsonResultViewModel jsonResultViewModel = new JsonResultViewModel();

            if (ModelState.IsValid)
            {
                if (model.Id != 0)
                {
                    Product pd = _context.Product.FirstOrDefault(p => p.Id == model.Id);
                    if (model.Img1File1 != null)
                    {
                        pd.Img1 = "/upload/productPicture/" + await _icommon.UploadProductPicture(model.Img1File1);
                    }
                    if (model.Img1File1 != null)
                    {
                        pd.Img2 = "/upload/productPicture/" + await _icommon.UploadProductPicture(model.Img1File2);
                    }
                    if (model.Img1File1 != null)
                    {
                        pd.Img3 = "/upload/productPicture/" + await _icommon.UploadProductPicture(model.Img1File3);
                    }
                    _context.Entry(pd).CurrentValues.SetValues(model);
                    _context.SaveChanges();
                    jsonResultViewModel.Success = true;
                    jsonResultViewModel.Mesaage = "Đã cập nhật thành công";
                    jsonResultViewModel.Object = model;
                    return Json(jsonResultViewModel);
                }
                else
                {
                    Product pd = new Product();
                    pd = model;

                    if (model.Img1File1 != null)
                    {
                        pd.Img1 = "/upload/productPicture/" + await _icommon.UploadProductPicture(model.Img1File1);
                    }
                    if (model.Img1File1 != null)
                    {
                        pd.Img2 = "/upload/productPicture/" + await _icommon.UploadProductPicture(model.Img1File2);
                    }
                    if (model.Img1File1 != null)
                    {
                        pd.Img3 = "/upload/productPicture/" + await _icommon.UploadProductPicture(model.Img1File3);
                    }
                    pd.CreatedBy = HttpContext.User.Identity.Name;
                    pd.CreatedDate = DateTime.Now;
                    _context.Add(pd);
                    _context.SaveChanges();
                    jsonResultViewModel.Success = true;
                    jsonResultViewModel.Mesaage = "Đã thêm thành công";
                    jsonResultViewModel.Object = model;
                    return Json(jsonResultViewModel);
                }

            }
            jsonResultViewModel.Success = false;
            jsonResultViewModel.Mesaage = "Dữ liệu thêm thất bại";
            jsonResultViewModel.Object = model;
            return Json(jsonResultViewModel);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            JsonResultViewModel jsonResultViewModel = new JsonResultViewModel();
            jsonResultViewModel.Success = false;
            jsonResultViewModel.Mesaage = "Xóa thất bại";
            jsonResultViewModel.Object = null;
            try
            {
                var product = _context.Product.Find(id);
                product.IsDeleted = true;
                _context.Update(product);
                _context.SaveChanges();
                jsonResultViewModel.Object = product;
                jsonResultViewModel.Success = true;
                jsonResultViewModel.Mesaage = "Xóa thành công";
                return Json(jsonResultViewModel);
            }
            catch (Exception ex)
            {
                return Json(jsonResultViewModel);
            }
        }

        [HttpGet]
        public IActionResult ChangeHotSale(int id)
        {
            Product pd = _context.Product.FirstOrDefault(p => p.Id == id);
            if (pd != null)
            {
                pd.HotSale = !pd.HotSale;
                _context.Update(pd);
                _context.SaveChanges();
                return Ok(pd);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult ChangeHotTrend(int id)
        {
            Product pd = _context.Product.FirstOrDefault(p => p.Id == id);
            if (pd != null)
            {
                pd.HotTrend = !pd.HotTrend;
                _context.Update(pd);
                _context.SaveChanges();
                return Ok(pd);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult StopProduct(int id)
        {
            Product pd = _context.Product.FirstOrDefault(p => p.Id == id);
            if (pd != null)
            {
                pd.Stop = !pd.Stop;
                _context.Update(pd);
                _context.SaveChanges();
                return Ok(pd);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
