using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basic_Calculator_MVC_G1.Models;
namespace BasicCalculatorApp.Tests.Models
{
    [TestFixture]
    public class CalculatorModelTests
    {
        [TestCase(4, 2, "+", 6)] //addition
        [TestCase(4, 2, "-", 2)] //subtraction
        [TestCase(4, 2, "*", 8)] //multiplication
        [TestCase(4, 2, "/", 2)] //division

        public void Calculate_ShouldReturnCorrectResult(double operand1, double operand2, string operation, double expectedResult) 
        { var model = new CalculatorModel { Operand1 = operand1, Operand2 = operand2, Operator = operation };
            model.Calculate();
            Assert.That(model.Result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Calculate_DivisionByZero_ShouldThrowExecption() 
        {
            var model = new CalculatorModel { Operand1 = 4, Operand2 = 0, Operator = "/" };
            var ex = Assert.Throws<System.DivideByZeroException>(() => model.Calculate());
            Assert.That(ex.Message, Is.EqualTo("Error: Division by zero is not allowed"));
        }
        }
    }

