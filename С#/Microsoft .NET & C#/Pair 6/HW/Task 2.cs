using System;
using System.Collections;
using System.Text;

namespace _06_interfaces
{
    public interface IOutput2
    {
        void ShowEven(); // Відображення парних значень
        void ShowOdd();  // Відображення непарних значень
    }

    // Розширюємо MyArray для реалізації інтерфейсу IOutput2
    public class MyArray : IMyCollection, IOutput2
    {
        private int[] data = Array.Empty<int>();
        public int Size { get; private set; } = 0;
        public int Position { get; private set; } = -1;

        public void AddValue(int value)
        {
            int[] tmp = new int[Size + 1];

            for (int i = 0; i < Size; i++)
            {
                tmp[i] = data[i];
            }

            tmp[Size++] = value;
            data = tmp;
        }

        public int GetValue()
        {
            return data[Position];
        }

        public void Next()
        {
            Position++;
            if (Size <= Position)
            {
                Position = -1;
            }
        }

        // Реалізація IOutput2
        public void ShowEven()
        {
            Console.WriteLine("Even numbers:");
            foreach (var value in data)
            {
                if (value % 2 == 0)
                {
                    Console.WriteLine(value);
                }
            }
        }

        public void ShowOdd()
        {
            Console.WriteLine("Odd numbers:");
            foreach (var value in data)
            {
                if (value % 2 != 0)
                {
                    Console.WriteLine(value);
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Створення та заповнення MyArray
            MyArray myArray = new MyArray();
            myArray.AddValue(6);
            myArray.AddValue(10);
            myArray.AddValue(-34);
            myArray.AddValue(463);
            myArray.AddValue(3413);
            myArray.AddValue(123);

            // Тестування методів ShowEven і ShowOdd
            myArray.ShowEven();
            Console.WriteLine();
            myArray.ShowOdd();
        }
    }
}
