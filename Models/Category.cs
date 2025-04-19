using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ims.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("itemCount")]
        public int ItemCount { get; set; }
        public string OrganizationId { get; set; }

    }
}
