using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EmployeeLeaveManagement_G1.Models;

namespace LeaveSystem.Tests
{
    [TestFixture]
    public class LeaveRequestTests
    {
        [Test]
        public void LeaveRequest_SetLeaveDates_ReturnsCorrectDates()
        {
            // Arrange
            var leaveRequest = new LeaveRequest();
            var startDate = new DateTime(2023, 10, 10);
            var endDate = new DateTime(2023, 10, 15);

            // Act
            leaveRequest.StartDate = startDate;
            leaveRequest.EndDate = endDate;

            // Assert
            Assert.AreEqual(startDate, leaveRequest.StartDate);
            Assert.AreEqual(endDate, leaveRequest.EndDate);
        }

        [Test]
        public void LeaveRequest_LeaveStartDateBeforeEndDate_ReturnsTrue()
        {
            // Arrange
            var leaveRequest = new LeaveRequest();
            leaveRequest.StartDate = new DateTime(2023, 10, 10);
            leaveRequest.EndDate = new DateTime(2023, 10, 15);

            // Act
            bool isValid = leaveRequest.StartDate < leaveRequest.EndDate;

            // Assert
            Assert.IsTrue(isValid);
        }

        [Test]
        public void LeaveRequest_CalculateLeaveDays_ReturnsCorrectDays()
        {
            // Arrange
            var leaveRequest = new LeaveRequest();
            leaveRequest.StartDate = new DateTime(2023, 10, 10);
            leaveRequest.EndDate = new DateTime(2023, 10, 15);

            // Act
            var leaveDays = (leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;

            // Assert
            Assert.AreEqual(5, leaveDays);
        }
    }
}

