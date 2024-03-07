using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CheesyCroco.Data
{
    public class Answer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();

        public string questionId { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public string text { get; set; } = "";

        public int score { get; set; } = 0;
    }
}