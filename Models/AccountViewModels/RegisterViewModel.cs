using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApp.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string? ConfirmPassword { get; set; }

        public static implicit operator ApplicationUser(RegisterViewModel vm)
        {
            return new ApplicationUser
            {
                UserName = vm.UserName,
                PhoneNumber = vm.PhoneNumber,
                Email = vm.Email,
            };
        }
    }
}