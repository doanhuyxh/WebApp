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
        public string Name { set; get; }

        [BsonElement("type")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Type { set; get; } // true là công cộng false là riêng tư

        [BsonElement("listUser")]
        [BsonRepresentation(BsonType.Array)]
        public List<string> ListUser { set; get; }
    }
}
