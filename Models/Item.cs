using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ims.Models
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] 
        public string Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string OrganizationId { get; set; }
        public BarcodeData Barcode { get; set; }
        public List<string> Images { get; set; } = [];
    }

    public class BarcodeData
    {
        public string Type { get; set; }
        public string BarcodeString { get; set; }
        public string BarcodeImage { get; set; }
    }
}
