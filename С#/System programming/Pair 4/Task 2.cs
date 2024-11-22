using System;
using System.Threading.Tasks;

class Program
{
    static void DisplayPrimes()
    {
        for (int i = 2; i <= 1000; i++)
        {
            if (IsPrime(i))
                Console.WriteLine(i);
        }
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    static void Main(string[] args)
    {
        var task = Task.Run(DisplayPrimes);
        task.Wait();

        Console.WriteLine("Task completed.");
    }
}
