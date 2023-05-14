using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.Models.AccountViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class UserManagerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserManagerController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.ListUser = (from _nd in _context.Users
                                select new UserProFileViewModel
                                {
                                    ApplicationUserId = _nd.Id,
                                    UserName = _nd.UserName,
                                    Email = _nd.Email,
                                    PhoneNumber = _nd.PhoneNumber,
                                    FisrtName = _nd.FirstName,
                                    LastName = _nd.LastName,
                                    AvatarPath = _nd.AvatartPath
                                }
                                ).ToList();
            return View();
        }
        public async Task<IActionResult> GetAllUser()
        {
            var listUser = await _context.Users.ToArrayAsync();
            return Ok(listUser);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return PartialView("_AddUser");
        }

        public async Task<IActionResult> AddEditUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return PartialView("_AddUser");
            }
            else
            {
                UserProFileViewModel user2 = new();
                user2.Email = user.Email;
                user2.PhoneNumber = user.PhoneNumber;
                user2.UserName = user.UserName;
                user2.FisrtName = user.FirstName;
                user2.LastName = user.LastName;
                user2.ApplicationUserId = user.Id;
                user2.AvatarPath = user.AvatartPath;
                return PartialView("_EditProFileUser", user2);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddEditUser(UserProFileViewModel vm)
        {
            if (string.IsNullOrEmpty(vm.ApplicationUserId))
            {
                //tao moi
            }
            else
            {
                ApplicationUser user = await _userManager.FindByEmailAsync(vm.Email);
                user.AvatartPath = vm.AvatarPath;
                user.FirstName = vm.FisrtName;
                user.LastName = vm.LastName;
                user.PhoneNumber = vm.PhoneNumber;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return Redirect("/Admin/Dashboard/Index");
                }
                else
                {
                    return PartialView("_EditProFileUser", vm);
                }
            }

            return PartialView("_EditProFileUser", vm);
        }
    }
}
