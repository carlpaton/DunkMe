using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Implementation;
using Repository.Schema;

namespace IntegrationTest
{
    [TestClass]
    public class GameTypeRepositoryTest
    {
        [TestMethod]
        public void Insert_returns_new_id()
        {
            var dbModel = new GameTypeModel
            {
                Name = "Test value",
                Description = "Some test description"
            };

            var newId = new GameTypeRepository().Insert(dbModel);
        }
    }
}
