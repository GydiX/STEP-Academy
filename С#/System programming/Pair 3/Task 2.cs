using System;
using System.Threading;

namespace ArraySumCalculation
{
    class Program
    {
        static int[] numbers;
        static long totalSum = 0;

        static void CalculatePartialSum(int start, int end)
        {
            long partialSum = 0;
            for (int i = start; i < end; i++)
            {
                partialSum += numbers[i];
            }
            Interlocked.Add(ref totalSum, partialSum);
        }

        static void Main(string[] args)
        {
            int arraySize = 1000000;
            numbers = new int[arraySize];
            Random rand = new Random();
            
            // Ініціалізуємо масив випадковими значеннями
            for (int i = 0; i < arraySize; i++)
            {
                numbers[i] = rand.Next(1, 100);
            }

            int threadCount = 5;
            Thread[] threads = new Thread[threadCount];
            int partitionSize = arraySize / threadCount;

            for (int i = 0; i < threadCount; i++)
            {
                int start = i * partitionSize;
                int end = (i == threadCount - 1) ? arraySize : start + partitionSize;
                threads[i] = new Thread(() => CalculatePartialSum(start, end));
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine($"Total sum of array elements: {totalSum}");
        }
    }
}
