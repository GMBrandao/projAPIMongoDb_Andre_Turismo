using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace projAPIMongoDb_Andre_Turismo.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
