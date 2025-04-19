using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ims.Models;
using ims.Utils;
using MongoDB.Driver;

namespace ims.Services
{
    public class ItemService
    {
        private readonly IMongoCollection<Item> _itemCollection;

        public ItemService()
        {
            var client = new MongoClient(Constants.MongoConnectionString);
            var database = client.GetDatabase(Constants.DatabaseName);
            _itemCollection = database.GetCollection<Item>(Constants.ItemCollection);
        }

        public async Task<List<Item>> GetAllItemsAsync()
        {
            if (!CacheManager.IsLoggedIn) throw new InvalidOperationException("User is not logged in.");
            return await _itemCollection.Find(i => i.OrganizationId == CacheManager.CurrentOrganizationId).ToListAsync();
        }

        public async Task<Item> GetItemByIdAsync(string id)
        {
            if (!CacheManager.IsLoggedIn) throw new InvalidOperationException("User is not logged in.");
            return await _itemCollection.Find(i =>
                i.Id == id && i.OrganizationId == CacheManager.CurrentOrganizationId).FirstOrDefaultAsync();
        }

        public async Task<List<Item>> GetItemsByNameAsync(string name)
        {
            if (!CacheManager.IsLoggedIn) throw new InvalidOperationException("User is not logged in.");
            return await _itemCollection.Find(i =>
                i.Name.ToLower() == name.ToLower() &&
                i.OrganizationId == CacheManager.CurrentOrganizationId
            ).ToListAsync();
        }

        public async Task<List<Item>> GetItemsByCategoryIdAsync(string categoryId)
        {
            if (!CacheManager.IsLoggedIn) throw new InvalidOperationException("User is not logged in.");
            if (string.IsNullOrWhiteSpace(categoryId)) throw new ArgumentNullException(nameof(categoryId));

            return await _itemCollection.Find(i =>
                i.CategoryId == categoryId &&
                i.OrganizationId == CacheManager.CurrentOrganizationId
            ).SortBy(i => i.Name).ToListAsync();
        }

        public async Task<List<Item>> GetItemsByCategoryIdsAsync(List<string> categoryIds)
        {
            if (!CacheManager.IsLoggedIn) throw new InvalidOperationException("User is not logged in.");
            if (categoryIds == null || categoryIds.Count == 0) return [];

            var filter = Builders<Item>.Filter.In(i => i.CategoryId, categoryIds) &
                         Builders<Item>.Filter.Eq(i => i.OrganizationId, CacheManager.CurrentOrganizationId);

            return await _itemCollection.Find(filter).ToListAsync();
        }

        public async Task<bool> CheckItemStockAsync(string itemId, int requestedQuantity)
        {
            if (!CacheManager.IsLoggedIn) throw new InvalidOperationException("User is not logged in.");

            var item = await GetItemByIdAsync(itemId);
            if (item == null)
                return false;

            return item.Quantity >= requestedQuantity;
        }

        public async Task AddItemAsync(Item item)
        {
            if (!CacheManager.IsLoggedIn) throw new InvalidOperationException("User is not logged in.");
            item.OrganizationId = CacheManager.CurrentOrganizationId;

            var exists = await _itemCollection.Find(i =>
                i.Name.ToLower() == item.Name.ToLower() &&
                i.OrganizationId == item.OrganizationId
            ).AnyAsync();

            if (exists)
                throw new Exception("Item with the same name already exists in your organization.");

            await _itemCollection.InsertOneAsync(item);
        }

        public async Task UpdateItemAsync(string id, Item updatedItem)
        {
            if (!CacheManager.IsLoggedIn) throw new InvalidOperationException("User is not logged in.");
            updatedItem.OrganizationId = CacheManager.CurrentOrganizationId;

            await _itemCollection.ReplaceOneAsync(i =>
                i.Id == id &&
                i.OrganizationId == updatedItem.OrganizationId,
                updatedItem
            );
        }

        public async Task DeleteItemAsync(string id)
        {
            if (!CacheManager.IsLoggedIn) throw new InvalidOperationException("User is not logged in.");
            await _itemCollection.DeleteOneAsync(i =>
                i.Id == id &&
                i.OrganizationId == CacheManager.CurrentOrganizationId
            );
        }
    }
}