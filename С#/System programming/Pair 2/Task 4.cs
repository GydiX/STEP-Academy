using System;
using System.Linq;
using System.Threading;

namespace ConsoleApp
{
    internal class Program
    {
        static int[] numbers = new int[10000];
        
        static void FindMax()
        {
            int max = numbers.Max();
            Console.WriteLine($"Максимум: {max}");
        }

        static void FindMin()
        {
            int min = numbers.Min();
            Console.WriteLine($"Мінімум: {min}");
        }

        static void FindAverage()
        {
            double average = numbers.Average();
            Console.WriteLine($"Середнє: {average}");
        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = rand.Next(1, 10000); // Заповнення випадковими числами

            Thread maxThread = new Thread(FindMax);
            Thread minThread = new Thread(FindMin);
            Thread averageThread = new Thread(FindAverage);

            maxThread.Start();
            minThread.Start();
            averageThread.Start();

            maxThread.Join();
            minThread.Join();
            averageThread.Join();
        }
    }
}
