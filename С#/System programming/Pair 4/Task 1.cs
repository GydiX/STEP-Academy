using System;
using System.Threading.Tasks;

class Program
{
    static void ShowCurrentDateTime()
    {
        Console.WriteLine($"Current Date and Time: {DateTime.Now}");
    }

    static void Main(string[] args)
    {
        // Через Start
        var task1 = new Task(ShowCurrentDateTime);
        task1.Start();

        // Через Task.Factory.StartNew
        var task2 = Task.Factory.StartNew(ShowCurrentDateTime);

        // Через Task.Run
        var task3 = Task.Run(ShowCurrentDateTime);

        // Очікування завершення всіх тасок
        Task.WaitAll(task1, task2, task3);

        Console.WriteLine("All tasks are completed.");
    }
}
