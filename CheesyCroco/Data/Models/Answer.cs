using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CheesyCroco.Data.Models
{
    public class Answer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        [BsonRepresentation(BsonType.ObjectId)]
        public string questionId { get; set; } = "";
        public string text { get; set; } = "";

        public int score { get; set; } = 0;
    }
}