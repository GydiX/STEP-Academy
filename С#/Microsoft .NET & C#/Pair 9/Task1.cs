using System;

namespace Pair_9
{
    public delegate void DisplayMessage(string message);

    internal class Task1
    {
        static void Main(string[] args)
        {
            DisplayMessage display = ConsoleMessage;
            display += UpperCaseMessage;
            display += RepeatMessage;

            Console.Write("Enter your message: ");
            string message = Console.ReadLine();

            Console.WriteLine("\nDisplaying message in different styles:");
            display.Invoke(message);
        }

        static void ConsoleMessage(string message)
        {
            Console.WriteLine("Console Message: " + message);
        }

        static void UpperCaseMessage(string message)
        {
            Console.WriteLine("Uppercase Message: " + message.ToUpper());
        }

        static void RepeatMessage(string message)
        {
            Console.WriteLine("Repeated Message: " + message + " " + message);
        }
    }
}
