using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace projAPIMongoDb_Andre_Turismo.Models
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string ZipCode { get; set; }
        public string Complement { get; set; }
        public City City { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
