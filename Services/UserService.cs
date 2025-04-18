using System.Collections.Generic;
using System.Threading.Tasks;
using ims.Models;
using ims.Utils;
using MongoDB.Driver;

namespace ims.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserService()
        {
            var client = new MongoClient(Constants.MongoConnectionString);
            var db = client.GetDatabase(Constants.DatabaseName);
            _userCollection = db.GetCollection<User>("users");
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userCollection.Find(_ => true).ToListAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _userCollection.Find(u => u.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _userCollection.Find(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(User user)
        {
            await _userCollection.InsertOneAsync(user);
        }

        public async Task UpdateAsync(string id, User updated)
        {
            await _userCollection.ReplaceOneAsync(u => u.Id == id, updated);
        }

        public async Task DeleteAsync(string id)
        {
            await _userCollection.DeleteOneAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetByOrganizationIdAsync(string orgId)
        {
            return await _userCollection.Find(u => u.OrganizationId == orgId).ToListAsync();
        }
    }
}
