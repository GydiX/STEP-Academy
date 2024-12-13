using System;

namespace Pair_9
{
    public delegate double ArithmeticOperation(double x, double y);

    internal class Task2
    {
        static void Main(string[] args)
        {
            ArithmeticOperation add = (a, b) => a + b;
            ArithmeticOperation subtract = (a, b) => a - b;
            ArithmeticOperation multiply = (a, b) => a * b;

            Console.Write("Enter first number: ");
            double num1 = double.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            double num2 = double.Parse(Console.ReadLine());

            Console.WriteLine("\nResults:");
            Console.WriteLine($"Addition: {add(num1, num2)}");
            Console.WriteLine($"Subtraction: {subtract(num1, num2)}");
            Console.WriteLine($"Multiplication: {multiply(num1, num2)}");
        }
    }
}
