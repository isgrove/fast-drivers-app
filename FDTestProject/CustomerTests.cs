using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FastDriversApp.v1.Models;

namespace FDTestProject
{
    // With Bit Services
    // In all (includes UnitTests as well as Integration test cases)
    // We need to produce at least 9 test cases
    // 3 test cases for client, contractor and job

    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void TestNames()
        {
            Customer newCustomer = new Customer(createHelper: false)
            {
                FirstName = "Jack",
                LastName = "Smith"
            };
            string expectedFirstName = "Jack";
            string expectedLastName = "Smith";
            Assert.AreEqual(newCustomer.FirstName, expectedFirstName);
            Assert.AreEqual(newCustomer.LastName, expectedLastName);
        }
    }
}
