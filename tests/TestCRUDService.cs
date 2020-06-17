using System;
using System.Collections.Generic;
using System.Text;
using MongoDbConnector;

namespace MongoDbConnector.tests
{
    class TestCRUDService : MongoCRUD<TestModel>
    {
        public TestCRUDService(IDatabaseSettings databaseSettings) : base(databaseSettings) { }
    }
}
