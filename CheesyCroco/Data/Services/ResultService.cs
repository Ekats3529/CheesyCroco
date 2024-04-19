﻿using MongoDB.Driver;
using MongoDB.Bson;
using System;
using CheesyCroco.Data.Models;
using CheesyCroco.Pages;

namespace CheesyCroco.Data.Services
{
    public class ResultService
    {

        public List<Result> results;
        IMongoDatabase database;
        IMongoCollection<Result> collection;
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
    }
}
