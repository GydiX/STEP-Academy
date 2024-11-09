using System;
using System.IO;

namespace Test_App
{
    internal class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Недостатньо аргументів. Введіть шлях до файлу та слово для пошуку.");
                return 1; 
            }

            string filePath = args[0]; 
            string searchWord = args[1]; 

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не знайдено.");
                return 1;
            }

            string fileContent = File.ReadAllText(filePath);
            int count = CountOccurrences(fileContent, searchWord);
            Console.WriteLine($"Слово '{searchWord}' зустрічається {count} разів у файлі.");
            return 0;
        }

        static int CountOccurrences(string content, string word)
        {
            int count = 0;
            int index = 0;

            while ((index = content.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += word.Length;
            }
            return count;
        }
    }
}