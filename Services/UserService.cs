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

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userCollection.Find(_ => true).ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userCollection.Find(u => u.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _userCollection.Find(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _userCollection.InsertOneAsync(user);
        }

        public async Task UpdateUserByIdAsync(string id, User updated)
        {
            await _userCollection.ReplaceOneAsync(u => u.Id == id, updated);
        }

        public async Task DeleteUserByIdAsync(string id)
        {
            await _userCollection.DeleteOneAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetUsersByOrganizationIdAsync(string orgId)
        {
            return await _userCollection.Find(u => u.OrganizationId == orgId).ToListAsync();
        }
    }
}
