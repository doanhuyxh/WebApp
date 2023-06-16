namespace WebApp.Repository
{
    public interface IMessengeChat
    {
        bool CreatedMessenge(string SenderId, string messenge, string ReceiverId);
    }
}
