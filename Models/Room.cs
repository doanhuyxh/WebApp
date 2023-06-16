using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApp.Models
{
    public class Room
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        [BsonRepresentation(BsonType.String)]
        public string RoomName { set; get; }

        [BsonElement("Messages")]
        [BsonRepresentation(BsonType.Boolean)]
        public string Messages { set; get; }

        [BsonElement("Members")]
        [BsonRepresentation(BsonType.Array)]
        public List<string> Members { set; get; }
    }
}
