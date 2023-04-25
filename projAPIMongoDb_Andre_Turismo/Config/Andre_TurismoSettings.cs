namespace projAPIMongoDb_Andre_Turismo.Config
{
    public class Andre_TurismoSettings : IAndre_TurismoSettings
    {
        public string CustomerCollectionName { get; set; }
        public string CityCollectionName { get; set; }
        public string AddressCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
