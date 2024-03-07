using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CheesyCroco.Data.Models
{
    public class Question
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [BsonRepresentation(BsonType.ObjectId)]
        public string testId { get; set; } = "";
        public string text { get; set; } = "";

        public int answersNum { get; set; } = 0;

        public int questionIndex { get; set; } = 0;
    }
}