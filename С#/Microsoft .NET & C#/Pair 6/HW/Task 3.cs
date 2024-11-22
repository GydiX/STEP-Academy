using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_interfaces
{
    // Інтерфейс ICalc2
    public interface ICalc2
    {
        int CountDistinct(); // Кількість унікальних значень
        int EqualToValue(int valueToCompare); // Кількість значень, рівних valueToCompare
    }

    // Модифікований клас MyArray, що імплементує ICalc2
    public class MyArray : IMyCollection, ICalc2
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

        // Реалізація CountDistinct
        public int CountDistinct()
        {
            return data.Distinct().Count();
        }

        // Реалізація EqualToValue
        public int EqualToValue(int valueToCompare)
        {
            return data.Count(v => v == valueToCompare);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Встановлення коректного кодування для консолі
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Створення екземпляру MyArray
            MyArray myArray = new MyArray();

            // Додавання значень
            myArray.AddValue(1);
            myArray.AddValue(2);
            myArray.AddValue(3);
            myArray.AddValue(2);
            myArray.AddValue(4);
            myArray.AddValue(1);
            myArray.AddValue(5);

            Console.WriteLine("Масив:");
            MyForeach.Foreach(myArray);

            // Тестування CountDistinct
            int uniqueCount = myArray.CountDistinct();
            Console.WriteLine($"\nКількість унікальних значень: {uniqueCount}");

            // Тестування EqualToValue
            int valueToCompare = 2;
            int equalCount = myArray.EqualToValue(valueToCompare);
            Console.WriteLine($"Кількість значень, рівних {valueToCompare}: {equalCount}");
        }
    }

    public static class MyForeach
    {
        public static void Foreach(IMyCollection collection)
        {
            collection.Next();
            while (collection.Position != -1)
            {
                Console.Write(collection.GetValue() + " ");
                collection.Next();
            }
        }
    }
}
