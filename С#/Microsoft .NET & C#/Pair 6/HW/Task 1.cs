using System;

namespace _06_interfaces
{
    // Інтерфейс ICalc
    public interface ICalc
    {
        int Less(int valueToCompare);
        int Greater(int valueToCompare);
    }

    // Реалізація класу MyArray з інтерфейсом ICalc
    public class MyArray : IMyCollection, ICalc
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

        // Реалізація методу Less
        public int Less(int valueToCompare)
        {
            int count = 0;
            foreach (int value in data)
            {
                if (value < valueToCompare)
                {
                    count++;
                }
            }
            return count;
        }

        // Реалізація методу Greater
        public int Greater(int valueToCompare)
        {
            int count = 0;
            foreach (int value in data)
            {
                if (value > valueToCompare)
                {
                    count++;
                }
            }
            return count;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Створення екземпляру MyArray
            MyArray myArray = new MyArray();

            // Додавання елементів у масив
            myArray.AddValue(5);
            myArray.AddValue(10);
            myArray.AddValue(-3);
            myArray.AddValue(8);
            myArray.AddValue(1);
            myArray.AddValue(20);

            // Виведення масиву
            Console.WriteLine("Масив:");
            MyForeach.Foreach(myArray);

            // Тестування методів Less та Greater
            int valueToCompare = 7;
            Console.WriteLine($"\nКількість елементів менших за {valueToCompare}: {myArray.Less(valueToCompare)}");
            Console.WriteLine($"Кількість елементів більших за {valueToCompare}: {myArray.Greater(valueToCompare)}");
        }
    }

    public static class MyForeach
    {
        public static void Foreach(IMyCollection collection)
        {
            collection.Next();
            while (collection.Position != -1)
            {
                Console.WriteLine(collection.GetValue());
                collection.Next();
            }
        }
    }

    public interface IMyCollection
    {
        int Position { get; }
        int GetValue();
        void Next();
    }
}
