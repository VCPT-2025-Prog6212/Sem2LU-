using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EmployeeLeaveManagement_G1.Models;

namespace LeaveSystem.Tests
{
    
    public class EmployeeTests
    {
        [Test]
        public void Employee_SetName_ReturnsCorrectName() 
        { 
            //Arrange - Set up the test & prepare the object for testing
            var employee = new Employee();

            //Act - This is where you perfom the action / operation for testing
            employee.Name = "John Doe";

            //Assert - verifies the action produced by the expected result
            Assert.AreEqual("John Doe", employee.Name);
        }

        [Test]
        public void Employees_SetDepartment_ReturnsCorrectDepartment() 
        {
            //arrange
            var employee = new Employee();
            //act
            employee.Department = "HR";
            //assert
            Assert.AreEqual("HR", employee.Department);
        
        
        }



    }
}
