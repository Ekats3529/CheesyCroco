using MongoDB.Driver;
using MongoDB.Bson;
using System;
using CheesyCroco.Data.Models;
using CheesyCroco.Settings;
using Microsoft.Extensions.Options;

namespace CheesyCroco.Data.Services
{
    public class QuestionService : IService<Question>
    {
        /*
        public List<Question> questions;
        public bool getCollection()
        {
            try
            {
                var database = client.GetDatabase("CheesyDB");
                var collection = database.GetCollection<Question>("Questions");

                questions = collection.Find(_ => true).ToList();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Task<Question[]> GetTestAsync()
        {
            return Task.FromResult(questions.ToArray());
        }
        */

        private IMongoCollection<Question> _questions;

        public QuestionService(IOptions<MongoDBSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _questions = database.GetCollection<Question>("Questions");
        }

        public List<Question> GetAll()
        {
            return _questions.Find(FilterDefinition<Question>.Empty).ToList();
        }

        public Question GetById(string id)
        {
            return _questions.Find(x => x.Id == id).FirstOrDefault();
        }

        public void SaveOrUpdate(Question obj)
        {
            var questionObj = _questions.Find(x => x.Id == obj.Id).FirstOrDefault();

            if (questionObj == null)
            {
                _questions.InsertOne(obj);
            }
            else
            {
                _questions.ReplaceOne(x => x.Id == obj.Id, obj);
            }
        }
    }
}
