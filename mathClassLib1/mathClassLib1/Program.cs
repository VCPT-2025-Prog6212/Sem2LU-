using System;
using MyMathClassLibrary;

namespace mathClassLib1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calc = new myCalculator();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ConsoleApp1 using MyMathClassLibrary");
            Console.ResetColor();

            Console.WriteLine($"5 + 3 = {calc.Add(5, 3)}");
            Console.WriteLine($"10 - 4 = {calc.Subtract(10, 4)}");

            Console.WriteLine($"8 * 9 = {calc.Multiply(8, 9)}");
            Console.WriteLine($"50 / 5 = {calc.Divide(50, 5)}");
            Console.WriteLine($"10 / 3 = {calc.Divide(10, 3)}");


        }
    }
}
