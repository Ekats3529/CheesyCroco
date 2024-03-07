using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CheesyCroco.Data.Models
{
    public class Result
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public string testId { get; set; } = ObjectId.GenerateNewId().ToString();

        public string name { get; set; } = "";

        public string text { get; set; } = "";

        public int scoreLimit { get; set; } = 0;
        public int userCount { get; set; } = 0;
    }
}