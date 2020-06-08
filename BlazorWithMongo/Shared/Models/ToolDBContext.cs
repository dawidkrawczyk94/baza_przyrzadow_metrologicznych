using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace BlazorWithMongo.Shared.Models
{
    public class ToolDBContext
    {   
        private readonly IMongoDatabase _mongoDatabase;
        public ToolDBContext()
        {
            var client = new MongoClient("mongodb+srv://dawidkrawczyk94:Dejw1214-k@cluster0-qacdj.mongodb.net/test?retryWrites=true&w=majority");
            _mongoDatabase = client.GetDatabase("metrologia");
        }
        public IMongoCollection<Tool> ToolRecord
        {
            get
            {
                return _mongoDatabase.GetCollection<Tool>("lista_przyrzadow");
            }
        }
       
    }

}
