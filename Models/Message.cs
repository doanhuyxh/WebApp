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

        [BsonElement("SenderId")]
        [BsonRepresentation(BsonType.String)]
        public string SenderId { get; set; }

        [BsonElement("ReceiverId")]
        [BsonRepresentation(BsonType.String)]
        public string ReceiverId { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonElement("TimeCreate")]
        public DateTime TimeCreate { get; set; }

        [BsonRepresentation(BsonType.Boolean)]
        [BsonElement("ReadStatus")]
        public bool ReadStatus { get; set; }
    }
}
