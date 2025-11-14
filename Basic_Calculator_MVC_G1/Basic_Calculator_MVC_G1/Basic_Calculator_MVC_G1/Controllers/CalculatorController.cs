using Basic_Calculator_MVC_G1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;

namespace Basic_Calculator_MVC_G1.Controllers
{
    public class CalculatorController : Controller
    {
        //GET
        public IActionResult Index()
        {
            return View();
        }
        //The POST method to handle form submission
        [HttpPost]
        public IActionResult Calculate(CalculatorModel model)
        {//check if the model is valid based on the attributes
            if (ModelState.IsValid)
            {
                try 
                {
                    //Perform the calculation using the Calculate method
                    model.Calculate();

                    // Add calculation to history after successful calculation
                    CalculatorModel history = new()
                    {
                        Operand1 = model.Operand1,
                        Operand2 = model.Operand2,
                        Operator = model.Operator,
                        Result = model.Result
                    };
                    HistoryUtil.hist.Add(history);
                }
                catch (Exception ex)
                {//Handle any errors during the calculation
                 //& add to the model state
                 ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            //Return the Index view with the updated model
            return View("Index", model);
        }

        public IActionResult History()
        {
            var history = HistoryUtil.hist;
            return View((history));
        }
    }
}
