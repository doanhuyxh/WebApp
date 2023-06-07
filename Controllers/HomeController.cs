using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Data;
using WebApp.Models;
using WebApp.Models.ViewModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly string user;

        public HomeController(IConfiguration configuration, ApplicationDbContext context, IHttpContextAccessor accessor)
        {
            _configuration = configuration;
            _context = context;
            user = accessor.HttpContext.User.Identity.Name;
        }
        public IActionResult ConFig()
        {
            JsonResultViewModel jsonResult = new JsonResultViewModel();
            ConfigShop cnf = new ConfigShop();
            cnf.LoGo = _configuration["ConfigShop:LoGo"];
            cnf.PhoneNumber = _configuration["ConfigShop:PhoneNumber"];
            cnf.Mail = _configuration["ConfigShop:Mail"];
            cnf.Address = _configuration["ConfigShop:Address"];
            cnf.TimeOnline = _configuration["ConfigShop:TimeOnline"];
            cnf.ImgSlie1 = _configuration["ConfigShop:ImgSlie1"];
            cnf.ImgSlie2 = _configuration["ConfigShop:ImgSlie2"];
            cnf.ImgSlie3 = _configuration["ConfigShop:ImgSlie3"];
            cnf.LinkChatFaceBook = _configuration["ConfigShop:LinkChatFaceBook"];
            cnf.TitleWeb = _configuration["ConfigShop:TitleWeb"];
            cnf.BannerRight1 = _configuration["ConfigShop:BannerRight1"];
            cnf.BannerRight2 = _configuration["ConfigShop:BannerRight2"];
            cnf.BannerRight3 = _configuration["ConfigShop:BannerRight3"];
            cnf.BannerButton1 = _configuration["ConfigShop:BannerButton1"];
            cnf.BannerButton2 = _configuration["ConfigShop:BannerButton2"];
            cnf.BannerButton3 = _configuration["ConfigShop:BannerButton3"];
            jsonResult.Success = true;
            jsonResult.Object = cnf;
            jsonResult.Mesaage = "Lấy thành công";
            return Json(jsonResult);
        }

        public IActionResult ProFile()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetProductHotSale()
        {
            JsonResultViewModel jsonResult = new JsonResultViewModel();
            try
            {
                var ds = from pd in _context.Product
                         where pd.HotSale == true && pd.IsDeleted == false && pd.Stop == false
                         select new ProductViewModel
                         {
                             Id = pd.Id,
                             Name = pd.Name,
                             Description = pd.Description,
                             Slug = pd.Slug,
                             Quantity = pd.Quantity,
                             HotSale = pd.HotSale,
                             HotTrend = pd.HotTrend,
                             Img1 = pd.Img1,
                             Img2 = pd.Img2,
                             Img3 = pd.Img3,
                             Price = pd.Price,
                             ProductCode = pd.ProductCode,
                             CategoryName = _context.Category.FirstOrDefault(i => i.Id == pd.CategoryId)!.Name ?? "",
                             BrandName = _context.Brand.FirstOrDefault(i => i.Id == pd.BrandId)!.BrandName ?? "",
                         };
                jsonResult.Success = true;
                jsonResult.Object = ds.ToList();
                jsonResult.Mesaage = "Lấy thành công HotSale";
                return Json(jsonResult);
            }
            catch (Exception ex)
            {
                jsonResult.Success = false;
                jsonResult.Mesaage = ex.Message;
                jsonResult.Object = null;
                return Json(jsonResult);
            }
        }
        [HttpGet]
        public IActionResult GetProductHotTrend()
        {
            JsonResultViewModel jsonResult = new JsonResultViewModel();
            try
            {
                var ds = from pd in _context.Product
                         where pd.HotTrend == true && pd.IsDeleted == false && pd.Stop == false
                         select new ProductViewModel
                         {
                             Id = pd.Id,
                             Name = pd.Name,
                             Description = pd.Description,
                             Slug = pd.Slug,
                             Quantity = pd.Quantity,
                             HotSale = pd.HotSale,
                             HotTrend = pd.HotTrend,
                             Img1 = pd.Img1,
                             Img2 = pd.Img2,
                             Img3 = pd.Img3,
                             Price = pd.Price,
                             ProductCode = pd.ProductCode,
                             CategoryName = _context.Category.FirstOrDefault(i => i.Id == pd.CategoryId)!.Name ?? "",
                             BrandName = _context.Brand.FirstOrDefault(i => i.Id == pd.BrandId)!.BrandName ?? "",
                         };
                jsonResult.Success = true;
                jsonResult.Object = ds.ToList();
                jsonResult.Mesaage = "Lấy thành công HotTrend";
                return Json(jsonResult);
            }
            catch (Exception ex)
            {
                jsonResult.Success = false;
                jsonResult.Mesaage = ex.Message;
                jsonResult.Object = null;
                return Json(jsonResult);
            }
        }
        [HttpGet]
        public IActionResult SearchProductByQuery(string query)
        {
            JsonResultViewModel jsonResult = new JsonResultViewModel();
            try
            {
                var ds = from pd in _context.Product
                         where (pd.IsDeleted == false && pd.Stop == false) && (pd.Name.Contains(query) || pd.Description.Contains(query) || pd.Slug.Contains(query))
                         select new ProductViewModel
                         {
                             Id = pd.Id,
                             Name = pd.Name,
                             Description = pd.Description,
                             Slug = pd.Slug,
                             Quantity = pd.Quantity,
                             HotSale = pd.HotSale,
                             HotTrend = pd.HotTrend,
                             Img1 = pd.Img1,
                             Img2 = pd.Img2,
                             Img3 = pd.Img3,
                             Price = pd.Price,
                             ProductCode = pd.ProductCode,
                             CategoryName = _context.Category.FirstOrDefault(i => i.Id == pd.CategoryId)!.Name ?? "",
                             BrandName = _context.Brand.FirstOrDefault(i => i.Id == pd.BrandId)!.BrandName ?? "",
                         };
                jsonResult.Success = true;
                jsonResult.Object = ds.ToList();
                jsonResult.Mesaage = "Lấy thành công HotTrend";
                return Json(jsonResult);
            }
            catch (Exception ex)
            {
                jsonResult.Success = false;
                jsonResult.Mesaage = ex.Message;
                jsonResult.Object = null;
                return Json(jsonResult);
            }
        }
        [HttpGet]
        public IActionResult AddToCart(CartViewModel vm)
        {
            JsonResultViewModel jsonResult = new JsonResultViewModel();
            try
            {
                if (ModelState.IsValid)
                {
                    Cart cart = new Cart();
                    cart = vm;
                    cart.CreatedBy = user;
                    cart.CreatedDate = DateTime.Now;
                    jsonResult.Success = true;
                    jsonResult.Object = cart;
                    jsonResult.Mesaage = "Thêm thành công";
                    return Json(jsonResult);

                }
                jsonResult.Success = false;
                jsonResult.Mesaage = "Có lỗi gửi dữ liệu lên";
                jsonResult.Object = null;
                return Json(jsonResult);
            }
            catch (Exception ex)
            {
                jsonResult.Success = false;
                jsonResult.Mesaage = ex.Message;
                jsonResult.Object = null;
                return Json(jsonResult);
            }
        }
        [HttpGet]
        public IActionResult GetCart()
        {
            JsonResultViewModel jsonResult = new JsonResultViewModel();
            try
            {
                var ds = from cr in _context.Cart
                         where cr.IsDeleted == false && cr.CreatedBy.Contains(user)
                         select new CartViewModel
                         {
                             Id = cr.Id,
                             ProductName = _context.Product.FirstOrDefault(p => p.Id == cr.ProductId).Name,
                             CreatedBy = cr.CreatedBy,
                             UnitPrice = cr.UnitPrice,
                             Quantity = cr.Quantity,
                             SubToTal = cr.SubToTal,
                             IsDeleted = cr.IsDeleted,
                             CreatedDate = cr.CreatedDate,
                             ProductId = cr.ProductId,
                         };

                jsonResult.Success = true;
                jsonResult.Mesaage = "Lấy dữ liệu thành công";
                jsonResult.Object = ds.ToList();
                return Json(jsonResult);
            }
            catch (Exception ex)
            {
                jsonResult.Success = false;
                jsonResult.Mesaage = ex.Message;
                jsonResult.Object = null;
                return Json(jsonResult);
            }
        }
        [HttpGet]
        public IActionResult DeleteCart(int cartId)
        {

            JsonResultViewModel jsonResult = new JsonResultViewModel();
            try
            {
                Cart cr = new Cart();
                cr = _context.Cart.FirstOrDefault(c => c.Id == cartId);
                cr.IsDeleted = true;
                _context.Update(cr);
                _context.SaveChanges();
                jsonResult.Success = true;
                jsonResult.Mesaage = "Đã xoá";
                jsonResult.Object = null;
                return Json(jsonResult);
            }
            catch (Exception ex)
            {
                jsonResult.Success = false;
                jsonResult.Mesaage = ex.Message;
                jsonResult.Object = null;
                return Json(jsonResult);
            }
        }
        [HttpGet]
        public IActionResult SearchByCateGoryries(int cateId)
        {
            JsonResultViewModel jsonResult = new JsonResultViewModel();
            try
            {
                var ds = from pd in _context.Product
                         where (pd.IsDeleted == false && pd.Stop == false) && pd.CategoryId == cateId
                         select new ProductViewModel
                         {
                             Id = pd.Id,
                             Name = pd.Name,
                             Description = pd.Description,
                             Slug = pd.Slug,
                             Quantity = pd.Quantity,
                             HotSale = pd.HotSale,
                             HotTrend = pd.HotTrend,
                             Img1 = pd.Img1,
                             Img2 = pd.Img2,
                             Img3 = pd.Img3,
                             Price = pd.Price,
                             ProductCode = pd.ProductCode,
                             CategoryName = _context.Category.FirstOrDefault(i => i.Id == pd.CategoryId)!.Name ?? "",
                             BrandName = _context.Brand.FirstOrDefault(i => i.Id == pd.BrandId)!.BrandName ?? "",
                         };
                jsonResult.Success = true;
                jsonResult.Object = ds.ToList();
                jsonResult.Mesaage = "Lấy thành công HotTrend";
                return Json(jsonResult);
            }
            catch (Exception ex)
            {
                jsonResult.Success = false;
                jsonResult.Mesaage = ex.Message;
                jsonResult.Object = null;
                return Json(jsonResult);
            }
        }

        [HttpGet]
        public IActionResult DetailProduct(int id)
        {
            ProductViewModel pd = _context.Product.FirstOrDefault(i => i.Id == id);
            return View(pd);
        }
    }
}