using MongoDB.Driver;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Repository
{
    public class MessengeChat : MongoDbContext, IMessengeChat
    {
        private readonly IMongoCollection<Messenge> _messengeCollection;

        public MessengeChat(IConfiguration configuration) : base(configuration)
        {
            _messengeCollection = this.dataBase.GetCollection<Messenge>(this.GetMessengesCollectionName());
        }

        public bool CreatedMessenge(string SenderId, string messenge, string ReceiverId)
        {
            try
            {
                Messenge ms = new Messenge();
                ms.SenderId = SenderId;
                ms.Content = messenge;
                ms.ReceiverId = ReceiverId;
                ms.ReadStatus = false;
                ms.TimeCreate = DateTime.Now;

                _messengeCollection.InsertOneAsync(ms);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
