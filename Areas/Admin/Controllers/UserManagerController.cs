using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models.AccountViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class UserManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserManagerController(ApplicationDbContext context)
        {
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
        public async Task<IActionResult> GetAllUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return Ok(user);
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
                //sua
            }

            return View(vm);
        }
    }
}
