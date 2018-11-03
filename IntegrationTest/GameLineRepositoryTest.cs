using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Implementation;
using Repository.Schema;

namespace IntegrationTest
{
    [TestClass]
    public class GameLineRepositoryTest
    {
        [TestMethod]
        public void Insert_returns_new_id_with_value_greater_than_zero()
        {
            // Arrange
            var dbModel = new GameLineModel
            {
                GameId = 1,
                Score = 1
            };

            // Act
            var newId = new GameLineRepository().Insert(dbModel);

            // Assert
            Assert.IsTrue(newId > 0);
        }

        [TestMethod]
        public void SelectListByGameId_given_id_returns_the_record()
        {
            // Arrange
            var givenId = 1;

            // Act
            var dbModel = new GameLineRepository().SelectListByGameId(givenId);

            // Assert
            foreach (var id in dbModel.Select(x => x.Id).ToList())
            {
                Assert.IsTrue(id == givenId);      
            }
        }
    }
}
