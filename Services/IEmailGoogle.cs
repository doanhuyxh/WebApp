namespace WebApp.Services
{
    public interface IEmailGoogle
    {
        string SendMailChangePassWork(string email, string newPass);
    }
}
