using System;
using System.Threading.Tasks;

class Program
{
    static void DisplayPrimesInRange(int start, int end)
    {
        int count = 0;
        for (int i = start; i <= end; i++)
        {
            if (IsPrime(i))
            {
                Console.WriteLine(i);
                count++;
            }
        }
        Console.WriteLine($"Total prime numbers: {count}");
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
        int start = 0, end = 1000;
        var task = Task.Run(() => DisplayPrimesInRange(start, end));
        task.Wait();

        Console.WriteLine("Task completed.");
    }
}
