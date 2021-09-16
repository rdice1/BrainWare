using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Web.DataAccessLayer;

namespace Tests.DataAccessLayer
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetOrders()
        {
            // Arrange
            // Set database to a known state; using original data as known state
            DataAccess da = new DataAccess();

            // Act
            var orders = da.GetOrders();

            // Assert
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count == 12);  // Data is in a known state
            Assert.IsTrue(orders[0].OrderProducts.Count > 0);
        }
    }
}
