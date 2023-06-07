namespace WebApp.Services
{
    public interface ICommon
    {
        Task<string> UploadAvatar(IFormFile avatar);
        Task<string> UploadProductPicture(IFormFile picture);
    }
}
