using System;

namespace InterfaceTask
{
    public interface IMath
    {
        int Max();
        int Min();
        float Avg();
        bool Search(int valueToSearch);
    }

    public class Array : IOutput, IMath
    {
        private int[] _array;

        public Array(int size)
        {
            _array = new int[size];
            for (int i = 0; i < size; i++)
            {
                _array[i] = i * 10; // Заповнення масиву тестовими значеннями
            }
        }

        // IOutput methods
        public void Show()
        {
            foreach (var item in _array)
            {
                Console.WriteLine(item);
            }
        }

        public void Show(string info)
        {
            Console.WriteLine(info);
            foreach (var item in _array)
            {
                Console.WriteLine(item);
            }
        }

        // IMath methods
        public int Max()
        {
            return _array.Length > 0 ? _array[0] : 0;
        }

        public int Min()
        {
            return _array.Length > 0 ? _array[0] : 0;
        }

        public float Avg()
        {
            float sum = 0;
            foreach (var item in _array)
            {
                sum += item;
            }
            return sum / _array.Length;
        }

        public bool Search(int valueToSearch)
        {
            foreach (var item in _array)
            {
                if (item == valueToSearch)
                    return true;
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Array array = new Array(5);

            Console.WriteLine("Max value: " + array.Max());
            Console.WriteLine("Min value: " + array.Min());
            Console.WriteLine("Average value: " + array.Avg());
            Console.WriteLine("Search for 20: " + array.Search(20));
            Console.WriteLine("Search for 100: " + array.Search(100));
        }
    }
}
