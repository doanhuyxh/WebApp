using MongoDB.Driver;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Repository
{
    public class RoomChart : MongoDbContext, IRoomChart
    {
        private readonly IMongoCollection<Room> _roomCollection;

        public RoomChart(IConfiguration configuration) : base(configuration)
        {
            _roomCollection = this.dataBase.GetCollection<Room>(this.GetRoomsCollectionName());
        }
    }
}
