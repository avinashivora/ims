using System.Collections.Generic;
using System.Threading.Tasks;
using ims.Models;
using ims.Utils;
using MongoDB.Driver;

namespace ims.Services
{
    public class OrganizationService
    {
        private readonly IMongoCollection<Organization> _organizationCollection;

        public OrganizationService()
        {
            var client = new MongoClient(Constants.MongoConnectionString);
            var db = client.GetDatabase(Constants.DatabaseName);
            _organizationCollection = db.GetCollection<Organization>("organizations");
        }

        public async Task<List<Organization>> GetAllAsync()
        {
            return await _organizationCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Organization> GetByIdAsync(string id)
        {
            return await _organizationCollection.Find(o => o.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Organization org)
        {
            await _organizationCollection.InsertOneAsync(org);
        }

        public async Task UpdateAsync(string id, Organization updated)
        {
            await _organizationCollection.ReplaceOneAsync(o => o.Id == id, updated);
        }

        public async Task DeleteAsync(string id)
        {
            await _organizationCollection.DeleteOneAsync(o => o.Id == id);
        }
    }
}
