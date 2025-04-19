using System.Configuration;

namespace ims.Utils
{
    public static class Constants
    {
        public static readonly string MongoConnectionString = ConfigurationManager.AppSettings["MongoDbConnectionString"];
        public static readonly string DatabaseName = ConfigurationManager.AppSettings["MongoDbDatabaseName"];
        public const string CategoryCollection = "categories";
        public const string ItemCollection = "items";
        public const string OrganizationCollection = "organizations";
        public const string UserCollection = "users";
        public const string BillCollection = "bills";
    }
}
