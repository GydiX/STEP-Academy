using System;

namespace InterfaceTask
{
    public interface IOutput
    {
        void Show();
        void Show(string info);
    }

    public class Array : IOutput
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            Array array = new Array(5);

            Console.WriteLine("Show() without info:");
            array.Show();

            Console.WriteLine("\nShow() with info:");
            array.Show("Array Elements:");
        }
    }
}
