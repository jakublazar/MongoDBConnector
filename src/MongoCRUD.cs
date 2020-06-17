using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace MongoDbConnector
{
    public abstract class MongoCRUD<T> : IMongoCRUD<T> where T : IObjectIdentity
    {
        private readonly IMongoCollection<T> _models;

        public MongoCRUD(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _models = database.GetCollection<T>(settings.CollectionName);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return _models.Find(new BsonDocument()).ToList<T>();
        }

        public virtual T GetOne(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            return _models.Find(filter).FirstOrDefault();
        }

        public virtual ObjectId Upsert(T model)
        {
            if (model.Id == ObjectId.Empty)
            {
                model.Id = ObjectId.GenerateNewId();
                _models.InsertOne(model);
            }
            else
            {
                _models.ReplaceOne(
                    new BsonDocument("_id", model.Id),
                    model,
                    new ReplaceOptions { IsUpsert = true });
            }
            return model.Id;
        }

        public virtual void Delete(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            _models.DeleteOne(filter);
        }
    }
}