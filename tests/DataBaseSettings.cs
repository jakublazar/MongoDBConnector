namespace MongoDbConnector.tests
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public DatabaseSettings(string collection, string cntString, string dbName)
        {
            CollectionName = collection;
            ConnectionString = cntString;
            DatabaseName = dbName;
        }
    }
}