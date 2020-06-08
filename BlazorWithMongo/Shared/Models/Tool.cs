using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BlazorWithMongo.Shared.Models
{
  
    public class Tool
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        public string numer_przyrzadu { get; set; }
        [Required]
        public string nazwa { get; set; }
        [Required]
        public string wlasciciel { get; set; }
      
        public string dzial { get; set; }
   
        public System.DateTime data_ostatniej_kontroli { get; set; }

        public System.DateTime data_nastepnej_kontroli { get; set; }
    }
}
