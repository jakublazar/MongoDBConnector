    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDbConnector;

namespace MongoDbConnector.tests
{
    public class TestModel : IObjectIdentity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; } = ObjectId.Empty;

        [BsonElement("Name")]
        public string Name { get; set; }

        public TestModel(string name)
        {
            Name = name;
        }
    }
}