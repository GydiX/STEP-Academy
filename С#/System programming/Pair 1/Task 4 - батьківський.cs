using System;
using System.Diagnostics;

namespace ParentProcess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string childProcessPath = @"C:\itstep\2 Семестр\СПР311\SP\01_processes\01_processes\Test_App\bin\Debug\net7.0\Test_App.exe";
            string filePath = @"D:\STEP-Academy\С#\Cистемне програмування\Pair 1\hello.txt";
            string searchWord = "bicycle";

            Process childProcess = Process.Start(childProcessPath, $"{filePath} {searchWord}");
            childProcess.WaitForExit();

            Console.WriteLine("Дочірній процес завершено з кодом: " + childProcess.ExitCode);
        }
    }
}
