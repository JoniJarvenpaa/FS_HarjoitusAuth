using MongoDB.Driver;

namespace SecondMVC.Models.Services
{
    public static class MongoManipulator
    {
        private const string DATABASE_NAME = "test_db";
        private const string DATABASE_ADDRESS = "127.0.0.1";
        private static readonly MongoServerAddress address = new MongoServerAddress(DATABASE_ADDRESS);
        private static readonly MongoClientSettings settings = new MongoClientSettings() { Server = address };
        private static readonly MongoClient client = new MongoClient(settings);
        private static IMongoDatabase database = client.GetDatabase(DATABASE_NAME);

        public static User SaveUser(User user)
        {
            var mongoTable = database.GetCollection<User>("User");
            mongoTable.InsertOne(user);
            return user;
        }
        public static UserTrimmed GetUserByUsername(string username)
        {
            var mongoTable = database.GetCollection<UserTrimmed>("User");
            var filter = Builders<UserTrimmed>.Filter.Eq("username", username);
            return mongoTable.Find(filter).FirstOrDefault();
        }

        public static Doggo SaveDoggo(Doggo koire)
        {
            var mongoTable = database.GetCollection<Doggo>("Doggo_backup");
            mongoTable.InsertOne(koire);
            return koire;
        }
    }
}
