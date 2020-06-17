using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbConnector
{
    public interface IObjectIdentity
    {
        public ObjectId Id { get; set; }
    }
}
