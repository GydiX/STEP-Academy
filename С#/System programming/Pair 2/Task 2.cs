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
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Введіть початок діапазону: ");
            int start = int.Parse(Console.ReadLine());

            Console.Write("Введіть кінець діапазону: ");
            int end = int.Parse(Console.ReadLine());

            Thread thread = new Thread(() => PrintNumbers(start, end));
            thread.Start();
        }
    }
}
