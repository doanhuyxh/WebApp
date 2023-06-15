using MongoDB.Driver;
using WebApp.Models;

namespace WebApp.Data
{

    public class MongoDbContext
    {

        private readonly IConfiguration configuration;

        private readonly string ConnectionString;

        private readonly string DatabaseName;

        private readonly string MessengesCollectionName;

        private readonly string RoomsCollectionName;

        public IMongoDatabase dataBase { get; set; }

        public MongoDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            ConnectionString = configuration["ChatRealTimeDatabase:ConnectionString"] ?? "";

            DatabaseName = configuration["ChatRealTimeDatabase:DatabaseName"] ?? "";

            MessengesCollectionName = configuration["ChatRealTimeDatabase:MessengesCollectionName"] ?? "";

            RoomsCollectionName = configuration["ChatRealTimeDatabase:RoomsCollectionName"] ?? "";

            ConnectDB();

        }

        public string GetConnectionString()
        {
            return ConnectionString;
        }
        public string GetDatabaseName()
        {
            return DatabaseName;
        }
        public string GetMessengesCollectionName()
        {
            return MessengesCollectionName;
        }
        public string GetRoomsCollectionName()
        {
            return RoomsCollectionName;
        }

        public void ConnectDB()
        {
            var client = new MongoClient(ConnectionString);
            var database = client.GetDatabase(DatabaseName);
            this.dataBase = database;
        }

    }
}
