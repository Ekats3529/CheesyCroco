using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CheesyCroco.Data.Models
{
    public class Result
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        
        [BsonRepresentation(BsonType.ObjectId)]
        public string testId { get; set; } = "";

        public string name { get; set; } = "";

        public string text { get; set; } = "";

        public int scoreMin { get; set; } = 0;

        public int scoreMax { get; set; } = 0;

        public int userCount { get; set; } = 0;

        public string imagePath { get; set; } = "";
    }
}