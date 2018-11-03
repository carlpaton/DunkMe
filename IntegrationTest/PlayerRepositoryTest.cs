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
    }
}
