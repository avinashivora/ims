using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ims.Models
{
    public enum UserRole
    {
        Admin,
        Manager,
        Staff
    }

    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public UserRole Role { get; set; }

        public string OrganizationId { get; set; }

        public string CreatedBy { get; set; }

        public bool FirstLogin { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
