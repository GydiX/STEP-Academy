using System;
using System.Threading;

namespace ConsoleApp
{
    internal class Program
    {
        static void PrintNumbers()
        {
            for (int i = 0; i <= 50; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(100); // Затримка для зручності перегляду
            }
        }

        static void Main(string[] args)
        {
            Thread thread = new Thread(PrintNumbers);
            thread.Start();
        }
    }
}
