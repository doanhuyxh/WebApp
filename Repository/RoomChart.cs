using WebApp.Data;

namespace WebApp.Repository
{
    public class RoomChart : MongoDbContext, IRoomChart
    {
        public RoomChart(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
