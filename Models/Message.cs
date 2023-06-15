using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApp.Models
{
    public class Messenge
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("content")]
        [BsonRepresentation(BsonType.String)]
        public string Content { get; set; }

        [BsonElement("userId")]
        [BsonRepresentation(BsonType.String)]
        public string UserId { get; set; }

        [BsonElement("roomId")]
        [BsonRepresentation(BsonType.String)]
        public string RoomId { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonElement("timeCreate")]
        public DateTime TimeCreate { get; set; }
    }
}
