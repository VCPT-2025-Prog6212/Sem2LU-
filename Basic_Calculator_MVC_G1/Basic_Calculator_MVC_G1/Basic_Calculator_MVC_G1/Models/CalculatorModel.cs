using System.ComponentModel.DataAnnotations;

namespace Basic_Calculator_MVC_G1.Models
{
    //the model for Calculator
    //contains properties for operands & result
    public class CalculatorModel
    {
        private object operand1;
        private object operand2;
        private object operation;
        private object result;

        public CalculatorModel()
        {
        }

        public CalculatorModel(object operand1, object operand2, object operation, object result)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
            this.operation = operation;
            this.result = result;
        }

        //Operand 1: the first number in the calculation
        [Required (ErrorMessage ="Please enter the first number")]
        [Range (double.MinValue, double.MaxValue, ErrorMessage = "Invalid Number.")]
        public double Operand1 { get; set; }

        //Operand 2: the second number in the calculation
        [Required(ErrorMessage = "Please enter the second number")]
        [Range(double.MinValue, double.MaxValue, ErrorMessage = "Invalid Number.")]
        public double Operand2 { get; set; }

        //Operator: the mathematical operator for the calculation
        [Required(ErrorMessage = "Please select an operator.")]
        public string Operator { get; set; }

        //Result: the result of the calculation
        public double Result { get; set; }

        //Method to perform the calculation based on the operator provided
        public void Calculate() 
        { try
            {
                switch (Operator)
                {
                    case "+":
                        Result = Operand1 + Operand2;
                        break;
                    case "-":
                        Result = Operand1 - Operand2;
                        break;
                    case "*":
                        Result = Operand1 * Operand2;
                        break;
                    case "/":
                        if (Operand2 == 0)
                        {
                            throw new DivideByZeroException("Division by zero not allowed");
                        }
                        Result = Operand1 / Operand2;
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operator");
                }
            }
            catch (DivideByZeroException ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
            catch (Exception ex) 
            {
                throw new Exception($"An error occured during the calculation: {ex.Message}");
            }
        }

    }
}
