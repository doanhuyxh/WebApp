using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class ConfigShopController : Controller
    {
        private readonly IConfiguration _configuration;

        public ConfigShopController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewData["CurrentPage"] = "Cấu hình hệ thống shop";

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

            return View(cnf);
        }

    }
}
