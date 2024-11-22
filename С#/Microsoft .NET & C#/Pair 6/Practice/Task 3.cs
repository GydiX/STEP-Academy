using System;

namespace InterfaceTask
{
    public interface ISort
    {
        void SortAsc();
        void SortDesc();
        void SortByParam(bool isAsc);
    }

    public class Array : IOutput, IMath, ISort
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

        // ISort methods
        public void SortAsc()
        {
            Array.Sort(_array);
        }

        public void SortDesc()
        {
            Array.Sort(_array);
            Array.Reverse(_array);
        }

        public void SortByParam(bool isAsc)
        {
            if (isAsc)
                SortAsc();
            else
                SortDesc();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Array array = new Array(5);

            Console.WriteLine("Array before sorting:");
            array.Show();

            array.SortAsc();
            Console.WriteLine("\nArray after SortAsc:");
            array.Show();

            array.SortDesc();
            Console.WriteLine("\nArray after SortDesc:");
            array.Show();

            array.SortByParam(false);
            Console.WriteLine("\nArray after SortByParam(false):");
            array.Show();
        }
    }
}
