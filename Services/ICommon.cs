namespace WebApp.Services
{
    public interface ICommon
    {
        Task<string> UploadAvatar(IFormFile avatar);
    }
}
