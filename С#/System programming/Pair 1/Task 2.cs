using System;
using System.Diagnostics;

namespace ParentProcess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string childProcessPath = @"C:\itstep\2 Семестр\СПР311\SP\01_processes\01_processes\Test_App\bin\Debug\net7.0\Test_App.exe";

            Process childProcess = Process.Start(childProcessPath);
            Console.WriteLine("Дочірній процес запущено. Продовжити чекати (y/n)?");

            string choice = Console.ReadLine();
            if (choice?.ToLower() == "y")
            {
                childProcess.WaitForExit();
                Console.WriteLine("Exit code: " + childProcess.ExitCode);
            }
            else
            {
                childProcess.Kill(); // Примусово завершуємо процес
                Console.WriteLine("Дочірній процес завершено примусово.");
            }
        }
    }
}
