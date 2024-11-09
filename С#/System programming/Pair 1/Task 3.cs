using System;

namespace Test_App
{
    internal class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Недостатньо аргументів. Введіть два числа та операцію (+, -, *, /).");
                return 1;
            }

            double num1 = Convert.ToDouble(args[0]);
            double num2 = Convert.ToDouble(args[1]);
            string operation = args[2];

            double result = 0;

            switch (operation)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0) result = num1 / num2;
                    else Console.WriteLine("Помилка: ділення на нуль.");
                    return 1;
                default:
                    Console.WriteLine("Невідома операція.");
                    return 1;
            }

            Console.WriteLine($"Аргументи: {num1}, {num2}, операція: {operation}");
            Console.WriteLine("Результат: " + result);
            return 0;
        }
    }
}
