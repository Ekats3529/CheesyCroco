using MongoDB.Driver;
using MongoDB.Bson;
using System;
using CheesyCroco.Data.Models;
using CheesyCroco.Settings;
using Microsoft.Extensions.Options;

namespace CheesyCroco.Data.Services
{
    public class TestService : IService<Test>
    {
        private IMongoCollection<Test> _tests;

        public TestService(IOptions<MongoDBSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _tests = database.GetCollection<Test>("Tests");
        }

        public List<Test> GetAll()
        {
            return _tests.Find(FilterDefinition<Test>.Empty).ToList();
        }

        public Test GetById(string id)
        {
            return _tests.Find(x => x.Id == id).FirstOrDefault();
        }

        public void SaveOrUpdate(Test obj)
        {
            var testObj = _tests.Find(x => x.Id == obj.Id).FirstOrDefault();

            if (testObj == null)
            {
                _tests.InsertOne(obj);
            }
            else
            {
                _tests.ReplaceOne(x => x.Id == obj.Id, obj);
            }
        }

        /*
        public List<Test> tests;
        IMongoDatabase database;
        IMongoCollection<Test> collection;

        public bool getCollection()
        {

            try
            {
                database = client.GetDatabase("CheesyDB");
                collection = database.GetCollection<Test>("Tests");
                tests = collection.Find(_ => true).ToList();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public Task<Test[]> GetTestAsync()
        {
            return Task.FromResult(tests.ToArray());
        }

        public bool SetNewRating(string testId, int rate)
        {
            foreach (var test in tests)
            {
                if (test.Id == testId)
                {
                    //test.rateNum++;
                    //test.rateSum += rate;

                    try
                    {

                        var filter = Builders<Test>.Filter.Eq(test => test.Id, testId);
                        var update1 = Builders<Test>.Update.Set(test => test.rateNum, test.rateNum + 1);
                        var update2 = Builders<Test>.Update.Set(test => test.rateSum, test.rateSum + rate);
                        collection.UpdateOne(filter, update1);
                        collection.UpdateOne(filter, update2);

                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            return false;
            // SAVING DATA

        }

        public bool SetNewPassesCount(string testId)
        {
            foreach (var test in tests)
            {
                if (test.Id == testId)
                {
                    //test.rateNum++;
                    //test.rateSum += rate;

                    try
                    {

                        var filterTest = Builders<Test>.Filter.Eq(test => test.Id, testId);
                        var updateTest = Builders<Test>.Update.Set(test => test.passCounter, test.passCounter + 1);

                        collection.UpdateOne(filterTest, updateTest);

                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            return false;
            // SAVING DATA

        }
        
        */

    }
}
