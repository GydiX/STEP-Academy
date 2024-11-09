using System;
using System.Threading;

namespace ConsoleApp
{
    internal class Program
    {
        static void PrintFibonacci(int n)
        {
            int a = 0, b = 1, next;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(a);
                next = a + b;
                a = b;
                b = next;
                Thread.Sleep(200);
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Введіть кількість чисел Фібоначчі: ");
            int count = int.Parse(Console.ReadLine());

            Thread fibonacciThread = new Thread(() => PrintFibonacci(count));
            fibonacciThread.Start();
        }
    }
}
