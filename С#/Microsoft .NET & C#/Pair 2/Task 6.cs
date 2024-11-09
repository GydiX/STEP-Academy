using System;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть текст: ");
            string input = Console.ReadLine();
            string result = CapitalizeFirstLetterOfSentences(input);
            Console.WriteLine($"Результат: {result}");
        }

        static string CapitalizeFirstLetterOfSentences(string text)
        {
            char[] buffer = text.ToCharArray();
            bool capitalizeNext = true;

            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] == '.' || buffer[i] == '!' || buffer[i] == '?')
                {
                    capitalizeNext = true; // Зміна на нове речення
                }
                else if (capitalizeNext && char.IsLetter(buffer[i]))
                {
                    buffer[i] = char.ToUpper(buffer[i]);
                    capitalizeNext = false;
                }
            }

            return new string(buffer);
        }
    }
}
