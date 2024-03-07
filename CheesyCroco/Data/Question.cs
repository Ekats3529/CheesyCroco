using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CheesyCroco.Data
{
    public class Question
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();

        public string testId { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public string text { get; set; } = "";

        public int answersNum { get; set; } = 0;

        public int questionIndex { get; set; } = 0;
    }
}