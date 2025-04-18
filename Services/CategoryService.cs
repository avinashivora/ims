using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ims.Models;
using ims.Utils;
using MongoDB.Driver;

namespace ims.Services
{
    public class CategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly ItemService _itemService;

        public CategoryService()
        {
            var client = new MongoClient(Constants.MongoConnectionString);
            var database = client.GetDatabase(Constants.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(Constants.CategoryCollection);
            _itemService = new ItemService();
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            if (!CacheManager.IsLoggedIn) throw new System.Exception("Not logged in.");
            return await _categoryCollection
                .Find(c => c.OrganizationId == CacheManager.CurrentOrganizationId)
                .ToListAsync();
        }

        public async Task<List<Category>> GetCategoriesWithItemCountsAsync()
        {
            var categories = await GetAllCategoriesAsync();
            var allItems = await _itemService.GetAllItemsAsync();

            var grouped = allItems
                .GroupBy(i => i.CategoryId)
                .ToDictionary(g => g.Key, g => g.Count());

            foreach (var cat in categories)
            {
                cat.ItemCount = grouped.TryGetValue(cat.Id, out int count) ? count : 0;
            }

            return categories;
        }

        public async Task UpdateAllCategoryItemCountsAsync()
        {
            var categories = await GetAllCategoriesAsync();
            var allItems = await _itemService.GetAllItemsAsync();

            var grouped = allItems
                .GroupBy(i => i.CategoryId)
                .ToDictionary(g => g.Key, g => g.Count());

            foreach (var category in categories)
            {
                int count = grouped.TryGetValue(category.Id, out var c) ? c : 0;
                var update = Builders<Category>.Update.Set(c => c.ItemCount, count);
                await _categoryCollection.UpdateOneAsync(c => c.Id == category.Id, update);
            }
        }

        public async Task<Category> GetCategoryByIdAsync(string id)
        {
            if (!CacheManager.IsLoggedIn) throw new System.Exception("Not logged in.");
            return await _categoryCollection.Find(c =>
                c.Id == id &&
                c.OrganizationId == CacheManager.CurrentOrganizationId
            ).FirstOrDefaultAsync();
        }

        public async Task<Dictionary<string, string>> GetCategoryNamesAsync()
        {
            var categories = await GetAllCategoriesAsync();
            return categories.ToDictionary(c => c.Id, c => c.Name);
        }

        public async Task AddCategoryAsync(Category category)
        {
            category.OrganizationId = CacheManager.CurrentOrganizationId;

            var exists = await _categoryCollection.Find(c =>
                c.Name.ToLower() == category.Name.ToLower() &&
                c.OrganizationId == category.OrganizationId
            ).AnyAsync();

            if (exists)
                throw new System.Exception("Category already exists in your organization.");

            await _categoryCollection.InsertOneAsync(category);
        }

        public async Task UpdateCategoryAsync(string id, Category updatedCategory)
        {
            updatedCategory.OrganizationId = CacheManager.CurrentOrganizationId;

            await _categoryCollection.ReplaceOneAsync(c =>
                c.Id == id &&
                c.OrganizationId == updatedCategory.OrganizationId,
                updatedCategory
            );
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(c =>
                c.Id == id &&
                c.OrganizationId == CacheManager.CurrentOrganizationId
            );
        }
    }
}
