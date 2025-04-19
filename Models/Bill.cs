using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace ims.Models
{
    public class Bill
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string BillNumber { get; set; }
        public string OrganizationId { get; set; }
        public string BilledBy { get; set; }
        public DateTime BillDate { get; set; }
        public List<BillItem> Items { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountType { get; set; } // 0 for flat, 1 for percentage
        public decimal DiscountValue { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal GrandTotal { get; set; }
        public string BillPath { get; set; } // Path to saved PDF
        public bool IsCheckedOut { get; internal set; }
    }

    public class BillItem
    {
        public string ItemId { get; set; }
        public string Barcode { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}