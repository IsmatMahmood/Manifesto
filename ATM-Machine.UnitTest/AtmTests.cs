using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ATM_Machine;

namespace ATM_Machine.UnitTest
{
    [TestClass]
    public class TestCheckForSufficentFunds_WithValidAmount_ShouldReturnTrue
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            new atm = new ATM_Machine.Atm(10000);

            //Act
            var result = atm.CheckForSufficentFunds(500);

            //Assert
            result.Should().Be(true);
        }
    }
}
