using MongoDB.Driver;
using projAPIMongoDb_Andre_Turismo.Config;
using projAPIMongoDb_Andre_Turismo.Models;

namespace projAPIMongoDb_Andre_Turismo.Services
{
    public class CityService
    {
        private readonly IMongoCollection<City> _city;

        public CityService(IAndre_TurismoSettings settings)
        {
            var city = new MongoClient(settings.ConnectionString);
            var database = city.GetDatabase(settings.DatabaseName);
            _city = database.GetCollection<City>(settings.CityCollectionName);
        }

        public List<City> Get() => _city.Find(c => true).ToList();

        public City Get(string id) => _city.Find<City>(c => c.Id == id).FirstOrDefault();

        public City Create(City city)
        {
            _city.InsertOne(city);
            return city;
        }

        public void Update(string id, City city) => _city.ReplaceOne(c => c.Id == id, city);

        public void Delete(string id) => _city.DeleteOne(c => c.Id == id);

        public void Delete(City city) => _city.DeleteOne(c => c.Id == city.Id);
    }
}
