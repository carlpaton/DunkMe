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
            // Arrange
            var dbModel = new GameTypeModel
            {
                Name = "Test value",
                Description = "Some test description"
            };

            // Act
            var newId = new GameTypeRepository().Insert(dbModel);

            // Assert
            Assert.IsTrue(newId > 0);
        }

        [TestMethod]
        public void SelectList_returns_more_than_one_record()
        {
            // Arrange
            // Act
            var dbModel = new GameTypeRepository().SelectList();

            // Assert
            Assert.IsTrue(dbModel.Count > 0);
        }
    }
}
