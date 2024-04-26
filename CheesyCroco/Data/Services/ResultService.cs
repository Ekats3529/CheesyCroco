using MongoDB.Driver;
using MongoDB.Bson;
using System;
using CheesyCroco.Data.Models;
using CheesyCroco.Settings;
using Microsoft.Extensions.Options;

namespace CheesyCroco.Data.Services
{
    public class ResultService : IService<Result>
    {
        private IMongoCollection<Result> _results;

        public ResultService(IOptions<MongoDBSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _results = database.GetCollection<Result>("Results");
        }

        public List<Result> GetAll()
        {
            return _results.Find(FilterDefinition<Result>.Empty).ToList();
        }

        public Result GetById(string id)
        {
            return _results.Find(x => x.Id == id).FirstOrDefault();
        }

        public void SaveOrUpdate(Result obj)
        {
            var resultObj = _results.Find(x => x.Id == obj.Id).FirstOrDefault();

            if (resultObj == null)
            {
                _results.InsertOne(obj);
            }
            else
            {
                _results.ReplaceOne(x => x.Id == obj.Id, obj);
            }
        }

        /*
        public List<Result> results;
        IMongoDatabase database;
        IMongoCollection<Result> collection;
        public bool getCollection()
        {
            try
            {
                database = client.GetDatabase("CheesyDB");
                collection = database.GetCollection<Result>("Results");

                results = collection.Find(_ => true).ToList();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Task<Result[]> GetTestAsync()
        {
            return Task.FromResult(results.ToArray());
        }

        public bool SetNewResultUserCount(string resId)
        {
            foreach (var result in results)
            {
                if (result.Id == resId)
                {

                    try
                    {

                        var filterResult = Builders<Result>.Filter.Eq(result => result.Id, resId);
                        var updateResult = Builders<Result>.Update.Set(result => result.userCount, result.userCount + 1);

                        collection.UpdateOne(filterResult, updateResult);

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
