namespace WebApp.Services
{
    public class EmailGoogle : IEmailGoogle
    {
        private readonly string _email;
        private readonly string _password;
        private readonly string _host;

        public EmailGoogle(IConfiguration _config)
        {
            _email = _config["SystemGoogleMail:Acc"];
        }

        public string SendMailChangePassWork(string email, string newPass)
        {
            try
            {

                return _email;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
