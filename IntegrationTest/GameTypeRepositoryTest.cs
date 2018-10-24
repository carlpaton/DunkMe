using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Implementation;
using Repository.Schema;

namespace IntegrationTest
{
    [TestClass]
    public class GameTypeRepositoryTest
    {
        [TestMethod]
        public void Insert_returns_new_id_with_value_greater_than_zero()
        {
            var dbModel = new GameTypeModel
            {
                Name = "Test value",
                Description = "Some test description"
            };

            var newId = new GameTypeRepository().Insert(dbModel);

            Assert.IsTrue(newId > 0);
        }
    }
}
