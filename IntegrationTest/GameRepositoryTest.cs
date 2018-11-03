using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Implementation;
using Repository.Schema;

namespace IntegrationTest
{
    [TestClass]
    public class GameRepositoryTest
    {
        [TestMethod]
        public void Insert_returns_new_id_with_value_greater_than_zero()
        {
            // Arrange
            var dbModel = new GameModel
            {
                GameTypeId = 1,
                PlayerId =  1
            };

            // Act
            var newId = new GameRepository().Insert(dbModel);

            // Assert
            Assert.IsTrue(newId > 0);
        }

        [TestMethod]
        public void SelectList_returns_more_than_one_record()
        {
            // Arrange
            // Act
            var dbModel = new GameRepository().SelectList();

            // Assert
            Assert.IsTrue(dbModel.Count > 0);
        }
    }
}
