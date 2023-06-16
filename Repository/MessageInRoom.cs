using MongoDB.Driver;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Repository
{
    public class MessageInRoom : MongoDbContext, IMessageInRoom
    {
        private readonly IMongoCollection<MessageInRooms> _mesInRom;

        public MessageInRoom(IConfiguration configuration) : base(configuration)
        {
            _mesInRom = this.dataBase.GetCollection<MessageInRooms>(this.GetMessageInRoomCollectionName());
        }
    }
}




