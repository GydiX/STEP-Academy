using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 3, 5, 3, 8, 6, 3, 5, 8, 10 };

        var distinctTask = Task.Run(() =>
        {
            int[] distinctArray = array.Distinct().ToArray();
            Console.WriteLine("Array without duplicates: " + string.Join(", ", distinctArray));
            return distinctArray;
        });

        var sortTask = distinctTask.ContinueWith(previousTask =>
        {
            int[] sortedArray = previousTask.Result.OrderBy(x => x).ToArray();
            Console.WriteLine("Sorted array: " + string.Join(", ", sortedArray));
            return sortedArray;
        });

        var searchTask = sortTask.ContinueWith(previousTask =>
        {
            int[] sortedArray = previousTask.Result;
            int target = 8;
            int index = Array.BinarySearch(sortedArray, target);
            Console.WriteLine(index >= 0
                ? $"Value {target} found at index {index}."
                : $"Value {target} not found.");
        });

        searchTask.Wait();
        Console.WriteLine("All tasks completed.");
    }
}
