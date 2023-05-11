using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email không được để trống")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Nhớ tôi?")]
        public bool RememberMe { get; set; }
    }
}
