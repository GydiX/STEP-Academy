using System;
using System.Threading;

namespace WebsiteVisitorCounter
{
    class Program
    {
        static int visitorCount = 0;

        static void SimulateVisitor()
        {
            for (int i = 0; i < 100; i++)
            {
                Interlocked.Increment(ref visitorCount);
            }
        }

        static void Main(string[] args)
        {
            int threadCount = 10;
            Thread[] threads = new Thread[threadCount];

            for (int i = 0; i < threadCount; i++)
            {
                threads[i] = new Thread(SimulateVisitor);
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine($"Total visitor count: {visitorCount}");
        }
    }
}
