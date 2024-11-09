using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть рядок для шифрування: ");
            string input = Console.ReadLine();
            int shift = 3; // Зсув для шифрування

            string encrypted = CaesarCipher(input, shift);
            Console.WriteLine($"Зашифрований рядок: {encrypted}");

            string decrypted = CaesarCipher(encrypted, -shift);
            Console.WriteLine($"Розшифрований рядок: {decrypted}");
        }

        static string CaesarCipher(string text, int shift)
        {
            char[] buffer = text.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                letter = (char)(letter + shift);
                buffer[i] = letter;
            }
            return new string(buffer);
        }
    }
}
