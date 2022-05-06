using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FastDriversApp.v1.Models;

namespace FDTestProject
{
    [TestClass]
    public class InstructorTests
    {
        [TestMethod]
        public void TestNames()
        {
            Instructor newInstructor = new Instructor(createHelper: false)
            {
                FirstName = "Jack",
                LastName = "Smith"
            };
            string expectedFirstName = "Jack";
            string expectedLastName = "Smith";
            Assert.AreEqual(newInstructor.FirstName, expectedFirstName);
            Assert.AreEqual(newInstructor.LastName, expectedLastName);
        }
    }
}