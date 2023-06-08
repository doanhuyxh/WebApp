using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.Models.AccountViewModels;
using WebApp.Services;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class UserManagerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly ICommon _icommon;

        public UserManagerController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ICommon icommon)
        {
            _userManager = userManager;
            _context = context;
            _icommon = icommon;
        }
        public IActionResult Index()
        {
            ViewData["CurrentPage"] = "Quản Lý Người Dùng";
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult DataUser()
        {
            var ds = (from _nd in _context.Users
                      select new UserProFileViewModel
                      {
                          ApplicationUserId = _nd.Id,
                          UserName = _nd.UserName,
                          Email = _nd.Email,
                          PhoneNumber = _nd.PhoneNumber,
                          FisrtName = _nd.FirstName,
                          LastName = _nd.LastName,
                          AvatarPath = _nd.AvatartPath,
                          IsActive = _nd.IsActive,
                      }).ToList();

            return Ok(ds);
        }

        public async Task<IActionResult> GetAllUser()
        {
            var listUser = await _context.Users.ToArrayAsync();
            return Ok(listUser);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            UserProFileViewModel user = new UserProFileViewModel();
            return PartialView("_AddUser", user);
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
                user2.Address = user.Address;
                return PartialView("_EditProFileUser", user2);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddEditUser(UserProFileViewModel vm)
        {
            JsonResultViewModel rs = new JsonResultViewModel();

            if (string.IsNullOrEmpty(vm.ApplicationUserId))
            {
                ApplicationUser user = new();
                user.AvatartPath = "/upload/avatar/" + await _icommon.UploadAvatar(vm.AvatarFile);
                user.UserName = vm.UserName;
                user.LastName = vm.LastName;
                user.UserName = vm.UserName;
                user.PhoneNumber = vm.PhoneNumber;
                user.Email = vm.Email;
                user.Address = vm.Address;
                user.IsActive = true;
                var result = await _userManager.CreateAsync(user, vm.Password);
                if (result.Succeeded)
                {
                    rs.Success = true;
                    rs.Object = user;
                    rs.Mesaage = "Đã Thêm mới user thành công";
                    return new JsonResult(rs);
                }
            }
            else
            {
                ApplicationUser user = await _userManager.FindByEmailAsync(vm.Email);
                if (vm.AvatarFile != null)
                {
                    user.AvatartPath = "/upload/avatar/" + await _icommon.UploadAvatar(vm.AvatarFile);
                }
                user.FirstName = vm.FisrtName;
                user.LastName = vm.LastName;
                user.PhoneNumber = vm.PhoneNumber;
                user.Address = vm.Address;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    rs.Success = true;
                    rs.Object = user;
                    rs.Mesaage = "Đã Cập nhật thành công";
                    return new JsonResult(rs);
                }
                else
                {
                    return PartialView("_EditProFileUser", vm);
                }
            }

            rs.Success = false;
            rs.Object = null;
            rs.Mesaage = "Đã xảy ra lỗi";
            return new JsonResult(rs);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeStatus(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            user.IsActive = !user.IsActive;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, password);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}
