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

        public bool CreatedMessenge(string userId, string messenge)
        {
            try
            {
                Messenge ms = new Messenge();
                ms.UserId = userId;
                ms.Content = messenge;
                ms.RoomId = "1";
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
