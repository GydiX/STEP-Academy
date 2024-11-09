using System;
using System.Diagnostics;

namespace ParentProcess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Шлях до дочірнього процесу
            string childProcessPath = @"C:\itstep\2 Семестр\СПР311\SP\01_processes\01_processes\Test_App\bin\Debug\net7.0\Test_App.exe";

            Process childProcess = Process.Start(childProcessPath);
            childProcess.WaitForExit(); // Чекаємо на завершення дочірнього процесу

            Console.WriteLine("Exit code: " + childProcess.ExitCode);
        }
    }
}
