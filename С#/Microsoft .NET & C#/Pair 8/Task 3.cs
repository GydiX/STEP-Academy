using System;
using System.Collections.Generic;

public class CafeQueue
{
    private Queue<string> regularQueue = new Queue<string>();
    private List<string> reservedList = new List<string>();

    public void AddVisitor(string name, bool hasReservation)
    {
        if (hasReservation)
        {
            reservedList.Add(name);
            Console.WriteLine($"Відвідувача {name} додано до списку резервацій.");
        }
        else
        {
            regularQueue.Enqueue(name);
            Console.WriteLine($"Відвідувача {name} додано до черги.");
        }
    }

    public void ServeNextVisitor()
    {
        if (reservedList.Count > 0)
        {
            string reservedVisitor = reservedList[0];
            reservedList.RemoveAt(0);
            Console.WriteLine($"Обслуговується зарезервований відвідувач: {reservedVisitor}");
        }
        else if (regularQueue.Count > 0)
        {
            string nextVisitor = regularQueue.Dequeue();
            Console.WriteLine($"Обслуговується звичайний відвідувач: {nextVisitor}");
        }
        else
        {
            Console.WriteLine("Немає відвідувачів у черзі.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CafeQueue queue = new CafeQueue();
        queue.AddVisitor("John", false);
        queue.AddVisitor("Jane", true);
        queue.AddVisitor("Alice", false);

        queue.ServeNextVisitor();
        queue.ServeNextVisitor();
        queue.ServeNextVisitor();
        queue.ServeNextVisitor();
    }
}
