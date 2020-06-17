using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MongoDbConnector
{
    public interface IMongoCRUD<T> where T : IObjectIdentity
    {
        public IEnumerable<T> GetAll();
        public T GetOne(ObjectId id);
        public ObjectId Upsert(T model);
        public void Delete(ObjectId id);
    }
}
