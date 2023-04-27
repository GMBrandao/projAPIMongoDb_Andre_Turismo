using MongoDB.Driver;
using projAPIMongoDb_Andre_Turismo.Config;
using projAPIMongoDb_Andre_Turismo.Models;

namespace projAPIMongoDb_Andre_Turismo.Services
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _address;
        private readonly IMongoCollection<City> _city;

        public AddressService(IAndre_TurismoSettings settings)
        {
            var address = new MongoClient(settings.ConnectionString);
            var database = address.GetDatabase(settings.DatabaseName);
            _address = database.GetCollection<Address>(settings.AddressCollectionName);
            _city = database.GetCollection<City>(settings.CityCollectionName);
        }

        public List<Address> Get() => _address.Find(c => true).ToList();

        public Address Get(string id) => _address.Find<Address>(c => c.Id == id).FirstOrDefault();

        public Address Create(Address address)
        {
            var city = _city.Find(c => c.Id == address.City.Id).FirstOrDefault();
            if (city == null)
                _city.InsertOne(address.City);
            else
                address.City = city;

            _address.InsertOne(address);
            return address;
        }

        public void Update(string id, Address address) => _address.ReplaceOne(a => a.Id == id, address);

        public void Delete(string id) => _address.DeleteOne(a => a.Id == id);

        public void Delete(Address address) => _address.DeleteOne(a => a.Id == address.Id);

    }
}
