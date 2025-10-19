using EmployeeLeaveManagement_G1.Controllers.LeaveRequestController;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveSystem.Tests
{
    [TestFixture]
    public class LeaveRequestControllerTests
    {
        private LeaveRequestController  _controller;

        [SetUp]
        public void Setup()
        {
            // Initialize the controller before each test
            _controller = new LeaveRequestController();
        }

        [Test]
        public void Index_Returns_ViewResult()
        {
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);  // Ensure that the result is not null
            Assert.IsTrue(result.ViewName == "" || result.ViewName == null);  // Check for implicit view name
        }

        [Test]
        public void Details_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var controller = new LeaveRequestController();

            // Act
            var result = controller.Details(-1) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundResult>(result);  // Ensures that an invalid ID returns NotFound
        }


        [Test]
        public void Details_ValidId_ReturnsViewResult()
        {
            // Arrange
            var controller = new LeaveRequestController();

            // Act
            var result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);  // Ensures it returns the correct view for valid ID
        }
        [TearDown]
        public void TearDown()
        {
            // Dispose the controller after each test to fix NUnit1032
            _controller?.Dispose();
            _controller = null;
        }
    }
}