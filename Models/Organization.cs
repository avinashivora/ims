using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ims.Models
{
    public class Organization
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string CreatedByUserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
