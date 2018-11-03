using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Implementation;
using Repository.Schema;

namespace IntegrationTest
{
    [TestClass]
    public class PlayerRepositoryTest
    {
        [TestMethod]
        public void Insert_returns_new_id_with_value_greater_than_zero()
        {
            // Arrange
            var dbModel = new PlayerModel
            {
                Email = "carl.paton@trademe.co.nz"
            };

            // Act
            var newId = new PlayerRepository().Insert(dbModel);

            // Assert
            Assert.IsTrue(newId > 0);
        }

        [TestMethod]
        public void SelectList_returns_more_than_one_record()
        {
            // Arrange
            // Act
            var dbModel = new PlayerRepository().SelectList();

            // Assert
            Assert.IsTrue(dbModel.Count > 0);
        }

        [TestMethod]
        public void Select_given_id_returns_the_record()
        {
            // Arrange
            var givenId = 1;

            // Act
            var dbModel = new PlayerRepository().Select(givenId);

            // Assert
            Assert.IsTrue(dbModel.Id == givenId);
        }
    }
}
