using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class UserManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserManagerController(ApplicationDbContext context) {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllUser()
        {
            var listUser = await _context.Users.ToArrayAsync();
            return Ok(listUser);
        }
    }
}
