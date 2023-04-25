namespace projAPIMongoDb_Andre_Turismo.Config
{
    public interface IAndre_TurismoSettings
    {
        string CustomerCollectionName { get; set; }
        string CityCollectionName { get; set; }
        string AddressCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}