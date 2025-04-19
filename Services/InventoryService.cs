using System.Threading.Tasks;
using MongoDB.Driver;
using ims.Models;
using ims.Utils;
using System;

namespace ims.Services
{
    public class InventoryService
    {
        private readonly IMongoCollection<Item> _itemCollection;

        public InventoryService()
        {
            var client = new MongoClient(Constants.MongoConnectionString);
            var database = client.GetDatabase(Constants.DatabaseName);
            _itemCollection = database.GetCollection<Item>(Constants.ItemCollection);
        }

        public async Task<Item> GetItemByBarcodeAsync(string barcode)
        {
            if (!CacheManager.IsLoggedIn)
                throw new InvalidOperationException("User is not logged in.");

            if (string.IsNullOrWhiteSpace(barcode))
                return null;

            string trimmedBarcode = barcode.Trim();

            return await _itemCollection.Find(i =>
                i.OrganizationId == CacheManager.CurrentOrganizationId &&
                i.Barcode != null &&
                i.Barcode.BarcodeString == trimmedBarcode
            ).FirstOrDefaultAsync();
        }


        public async Task UpdateStockQuantityAsync(string itemId, int quantityChange)
        {
            var update = Builders<Item>.Update.Inc(i => i.Quantity, quantityChange);
            await _itemCollection.UpdateOneAsync(i => i.Id == itemId, update);
        }
    }
}