using MongoDB.Driver;
using MongoDB.Bson;
using System;
using CheesyCroco.Data.Models;
using CheesyCroco.Settings;
using Microsoft.Extensions.Options;

namespace CheesyCroco.Data.Services
{
    public class AnswerService : IService<Answer>
    {
        /*
        public List<Answer> answers;

        public bool getCollection()
        {
            try
            {
                var database = client.GetDatabase("CheesyDB");
                var collection = database.GetCollection<Answer>("Answers");

                answers = collection.Find(_ => true).ToList();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Task<Answer[]> GetTestAsync()
        {
            return Task.FromResult(answers.ToArray());
        }
        */

        private IMongoCollection<Answer> _answers;

        public AnswerService(IOptions<MongoDBSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _answers = database.GetCollection<Answer>("Answers");
        }

        public List<Answer> GetAll()
        {
            return _answers.Find(FilterDefinition<Answer>.Empty).ToList();
        }

        public Answer GetById(string id)
        {
            return _answers.Find(x => x.Id == id).FirstOrDefault();
        }

        public void SaveOrUpdate(Answer obj)
        {
            var answerObj = _answers.Find(x => x.Id == obj.Id).FirstOrDefault();

            if (answerObj == null)
            {
                _answers.InsertOne(obj);
            }
            else
            {
                _answers.ReplaceOne(x => x.Id == obj.Id, obj);
            }
        }
    }
}
