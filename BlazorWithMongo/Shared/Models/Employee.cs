using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BlazorWithMongo.Shared.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string dzial { get; set; }
        [Required]
        public string nrew { get; set; }

        //[Required]
        //public int toolcount { get; set; }
    }
    
}
