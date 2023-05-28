using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public HomeController(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
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

    }
}