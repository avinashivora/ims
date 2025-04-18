using ims.Utils;
using MongoDB.Driver;

namespace ims.Data
{
    public static class Database
    {
        private static readonly MongoClient _client = new(Constants.MongoConnectionString);
        private static readonly IMongoDatabase _database = _client.GetDatabase(Constants.DatabaseName);

        public static IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
