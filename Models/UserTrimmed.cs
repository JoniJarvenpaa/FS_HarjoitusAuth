using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SecondMVC.Models
{
    [BsonIgnoreExtraElements]
    public class UserTrimmed : DB_SaveableObject
    {
        public string username { get; set; }
        public string password { get; set; }
        public UserTrimmed() { }
    }
}
