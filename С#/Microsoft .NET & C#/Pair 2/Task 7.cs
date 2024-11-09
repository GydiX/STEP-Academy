using System;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть текст: ");
            string input = Console.ReadLine();
            Console.Write("Введіть неприпустиме слово: ");
            string forbiddenWord = Console.ReadLine();

            string result = ReplaceForbiddenWords(input, forbiddenWord);
            Console.WriteLine($"Результат: {result}");
        }

        static string ReplaceForbiddenWords(string text, string forbiddenWord)
        {
            int count = 0;
            string replacedText = text.Replace(forbiddenWord, new string('*', forbiddenWord.Length), StringComparison.OrdinalIgnoreCase);
            count = (text.Length - replacedText.Length) / forbiddenWord.Length;

            Console.WriteLine($"Статистика: {count} заміни слова {forbiddenWord}.");
            return replacedText;
        }
    }
}
