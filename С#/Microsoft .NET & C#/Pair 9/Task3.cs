using System;

namespace Pair_9
{
    internal class Task3
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = n => n % 2 == 0;
            Predicate<int> isOdd = n => n % 2 != 0;
            Predicate<int> isPrime = IsPrime;
            Predicate<int> isFibonacci = IsFibonacci;

            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("\nNumber checks:");
            Console.WriteLine($"Is even: {isEven(number)}");
            Console.WriteLine($"Is odd: {isOdd(number)}");
            Console.WriteLine($"Is prime: {isPrime(number)}");
            Console.WriteLine($"Is Fibonacci: {isFibonacci(number)}");
        }

        static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        static bool IsFibonacci(int n)
        {
            int a = 0, b = 1, temp;
            while (b < n)
            {
                temp = a + b;
                a = b;
                b = temp;
            }
            return n == b || n == 0;
        }
    }
}
