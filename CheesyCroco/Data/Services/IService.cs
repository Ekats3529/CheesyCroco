using CheesyCroco.Data.Models;
using CheesyCroco.Pages;
using MongoDB.Driver;

namespace CheesyCroco.Data.Services
{
    public interface IService<T>
    {
        /*
        const string connectionUri = "mongodb+srv://user:passwordpassword@cluster.ncff76h.mongodb.net/?retryWrites=true&w=majority&appName=Cluster";

        MongoClientSettings settings;

        protected MongoClient client;

        public bool connect()
        {
            settings = MongoClientSettings.FromConnectionString(connectionUri);
            // Set the ServerApi field of the settings object to set the version of the Stable API on the client
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            // Create a new client and connect to the server
            client = new MongoClient(settings);
            return true;
        }
        */

        public T GetById(string id);

        public List<T> GetAll();

        public void SaveOrUpdate(T obj);

    }
}
