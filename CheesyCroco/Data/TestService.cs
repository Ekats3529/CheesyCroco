using MongoDB.Driver;
using MongoDB.Bson;


namespace CheesyCroco.Data
{
    public class TestService
    {
        public Boolean connect()
        {
            const string connectionUri = "mongodb+srv://user:passwordpassword@cluster.ncff76h.mongodb.net/?retryWrites=true&w=majority&appName=Cluster";

            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            // Set the ServerApi field of the settings object to set the version of the Stable API on the client
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            // Create a new client and connect to the server
            var client = new MongoClient(settings);


            // Send a ping to confirm a successful connection
            try
            {
                var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Task<Test[]> GetTestAsync()
        {
            

            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new Test
            {
                name = "Aaa",
                rate = 5,
                passCounter = 100000000
            }).ToArray());
        }
    }
}
