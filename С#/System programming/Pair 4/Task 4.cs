using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int[] array = Enumerable.Range(1, 100).Select(_ => new Random().Next(1, 1000)).ToArray();

        Task minTask = Task.Run(() =>
        {
            int min = array.Min();
            Console.WriteLine($"Minimum: {min}");
        });

        Task maxTask = Task.Run(() =>
        {
            int max = array.Max();
            Console.WriteLine($"Maximum: {max}");
        });

        Task sumTask = Task.Run(() =>
        {
            int sum = array.Sum();
            Console.WriteLine($"Sum: {sum}");
        });

        Task avgTask = Task.Run(() =>
        {
            double avg = array.Average();
            Console.WriteLine($"Average: {avg}");
        });

        Task.WaitAll(minTask, maxTask, sumTask, avgTask);
        Console.WriteLine("All calculations completed.");
    }
}
