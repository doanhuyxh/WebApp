namespace WebApp.Models.AccountViewModels
{
    public class UserProFileViewModel
    {
        public IFormFile AvatarFile { get; set; }
        public string Role { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string FisrtName { set; get; }
        public string LastName { set; get; }
        public string PasswordCompere { set; get; }
    }
}
