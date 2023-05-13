using Microsoft.AspNetCore.Identity;

namespace WebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string AvatartPath { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
    }
}
