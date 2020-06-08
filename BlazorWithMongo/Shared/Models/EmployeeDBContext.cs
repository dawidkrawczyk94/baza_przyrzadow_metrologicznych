using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace BlazorWithMongo.Shared.Models
{
    public class EmployeeDBContext
    {   
        private readonly IMongoDatabase _mongoDatabase;
        public EmployeeDBContext()
        {
            var client = new MongoClient("mongodb+srv://dawidkrawczyk94:Dejw1214-k@cluster0-qacdj.mongodb.net/test?retryWrites=true&w=majority");
            _mongoDatabase = client.GetDatabase("metrologia");
        }
        public IMongoCollection<Employee> EmployeeRecord
        {
            get
            {
                return _mongoDatabase.GetCollection<Employee>("lista_pracownikow");
            }
        }

    }

}
