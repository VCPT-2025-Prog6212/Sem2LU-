using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basic_Calculator_MVC_G1.Controllers;
using Basic_Calculator_MVC_G1.Models;
using Microsoft.AspNetCore.Mvc;


namespace BasicCalculatorApp.Tests.Controller
{
    [TestFixture]
    public class CalculatorControllerTests
    {
        private CalculatorController _calculatorController;


        [TearDown]
        public void TearDown()
        {
            _calculatorController.Dispose();
        }
        [SetUp]
        public void Setup() 
        { 
            _calculatorController = new CalculatorController();
        }
        

        [Test]
        public void Index_ReturnsViewResult() 
        { 
            var result = _calculatorController.Index();
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }

        [Test]
        public void Calculate_ValidModel_ReturnsCorrectResult()
        {
            var model = new CalculatorModel {Operand1 = 4, Operand2 = 2, Operator = "+" };
            var result = _calculatorController.Calculate(model);
            var viewResult = result as ViewResult;
            Assert.That(viewResult, Is.Not.Null);
            var returnedModel = viewResult.Model as CalculatorModel;
            Assert.That(returnedModel.Result, Is.EqualTo(6));

        }
        
    }
}
