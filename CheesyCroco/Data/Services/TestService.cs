using MongoDB.Driver;
using MongoDB.Bson;
using System;
using CheesyCroco.Data.Models;

namespace CheesyCroco.Data.Services
{
    public class TestService
    {

        public List<Test> tests;
        IMongoDatabase database;
        IMongoCollection<Test> collection;

        public bool connect()
        {
            const string connectionUri = "mongodb+srv://user:passwordpassword@cluster.ncff76h.mongodb.net/?retryWrites=true&w=majority&appName=Cluster";

            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            // Set the ServerApi field of the settings object to set the version of the Stable API on the client
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            // Create a new client and connect to the server
            var client = new MongoClient(settings);
            //

            // Send a ping to confirm a successful connection
            try
            {
                //var result = client.GetDatabase("CheesyDB").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
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

        public bool SetNewRating(string testId, int rate) {
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


    }
}
