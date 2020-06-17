using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDbConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbConnector.tests
{
    [TestClass()]
    public class MongoCRUDTests
    {
        private static readonly IDatabaseSettings db = new DatabaseSettings("testCollection", "mongodb://localhost:27017", "connectorTest");
        private readonly IMongoCRUD<TestModel> mongoCRUD = new TestCRUDService(db);
        public MongoCRUDTests()
        {

        }
        [TestMethod()]
        public void MongoCRUDTest()
        {
            TestModel firstModel = new TestModel("one");
            TestModel secondModel = new TestModel("two");
            
                ObjectId firstId = mongoCRUD.Upsert(firstModel);
                ObjectId secondId = mongoCRUD.Upsert(secondModel);

                Assert.AreEqual("one", mongoCRUD.GetOne(firstId).Name);
                Assert.AreEqual("two", mongoCRUD.GetOne(secondId).Name);

                firstModel.Name = "oneOne";
                firstModel.Id = firstId;

                secondModel.Name = "twoTwo";
                secondModel.Id = secondId;

                mongoCRUD.Upsert(firstModel);
                mongoCRUD.Upsert(secondModel);

                Assert.AreEqual("oneOne", mongoCRUD.GetOne(firstId).Name);
                Assert.AreEqual("twoTwo", mongoCRUD.GetOne(secondId).Name);

                mongoCRUD.Delete(firstId);
                mongoCRUD.Delete(secondId);

                Assert.IsNull(mongoCRUD.GetOne(firstId));
                Assert.IsNull(mongoCRUD.GetOne(secondId));
        }
    }
}