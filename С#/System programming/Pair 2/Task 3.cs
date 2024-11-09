using System;
using System.Threading;

namespace ConsoleApp
{
    internal class Program
    {
        static void PrintNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine($"Потік {Thread.CurrentThread.ManagedThreadId}: {i}");
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Введіть кількість потоків: ");
            int numThreads = int.Parse(Console.ReadLine());

            for (int i = 0; i < numThreads; i++)
            {
                Console.Write($"Введіть початок діапазону для потоку {i + 1}: ");
                int start = int.Parse(Console.ReadLine());

                Console.Write($"Введіть кінець діапазону для потоку {i + 1}: ");
                int end = int.Parse(Console.ReadLine());

                Thread thread = new Thread(() => PrintNumbers(start, end));
                thread.Start();
            }
        }
    }
}
