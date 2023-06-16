using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebApp.Models
{
    public class MessageInRooms
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Messages")]
        [BsonRepresentation(BsonType.Boolean)]
        public String Messages { set; get; }

        [BsonElement("RoomId")]
        [BsonRepresentation(BsonType.Boolean)]
        public String RoomId { set; get; }

        [BsonElement("SenderId")]
        [BsonRepresentation(BsonType.String)]
        public string SenderId { set; get; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonElement("TimeCreate")]
        public DateTime TimeCreate { get; set; }
    }
}
