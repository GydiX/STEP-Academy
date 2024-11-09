using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть арифметичний вираз (+, -): ");
            string input = Console.ReadLine();

            int result = EvaluateExpression(input);
            Console.WriteLine($"Результат: {result}");
        }

        static int EvaluateExpression(string expression)
        {
            string[] tokens = expression.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int result = int.Parse(tokens[0]);

            for (int i = 1; i < tokens.Length; i += 2)
            {
                string operation = tokens[i];
                int nextValue = int.Parse(tokens[i + 1]);

                if (operation == "+")
                {
                    result += nextValue;
                }
                else if (operation == "-")
                {
                    result -= nextValue;
                }
            }

            return result;
        }
    }
}
