using System;
using System.Text.RegularExpressions;

public class Program
{
    public static bool EvaluateExpression(string expression)
    {
        string pattern = @"^\s*(\d+)\s*(==|!=|<=|>=|<|>)\s*(\d+)\s*$";
        Match match = Regex.Match(expression, pattern);

        if (!match.Success)
        {
            throw new ArgumentException("Неправильний формат виразу!");
        }

        int leftOperand = int.Parse(match.Groups[1].Value);
        string operatorSymbol = match.Groups[2].Value;
        int rightOperand = int.Parse(match.Groups[3].Value);

        return operatorSymbol switch
        {
            "==" => leftOperand == rightOperand,
            "!=" => leftOperand != rightOperand,
            "<=" => leftOperand <= rightOperand,
            ">=" => leftOperand >= rightOperand,
            "<" => leftOperand < rightOperand,
            ">" => leftOperand > rightOperand,
            _ => throw new InvalidOperationException("Невідомий оператор!")
        };
    }

    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Введіть логічний вираз (наприклад, 3 > 2):");
            string input = Console.ReadLine();

            bool result = EvaluateExpression(input);
            Console.WriteLine($"Результат: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
