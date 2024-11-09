using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Оголошення масивів
            float[] A = new float[5];
            float[,] B = new float[3, 4];
            Random rnd = new Random();

            // Заповнення масиву A значеннями з клавіатури
            Console.WriteLine("Введіть 5 чисел для масиву A:");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write($"A[{i}]: ");
                A[i] = float.Parse(Console.ReadLine());
            }

            // Заповнення двовимірного масиву B випадковими числами
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = (float)rnd.NextDouble() * 100; // Випадкові дробові числа
                }
            }

            // Виведення масивів
            Console.WriteLine("\nМасив A:");
            foreach (var item in A)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nМасив B:");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write(B[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // Обчислення загальних значень
            float max = A[0];
            float min = A[0];
            float sumA = 0;
            float productA = 1;
            float sumEvenA = 0;

            for (int i = 0; i < A.Length; i++)
            {
                sumA += A[i];
                productA *= A[i];
                if (A[i] % 2 == 0)
                {
                    sumEvenA += A[i];
                }

                if (A[i] > max) max = A[i];
                if (A[i] < min) min = A[i];
            }

            float sumB = 0;
            float productB = 1;

            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    sumB += B[i, j];
                    productB *= B[i, j];
                }
            }

            Console.WriteLine($"\nЗагальний максимальний елемент: {Math.Max(max, productB)}");
            Console.WriteLine($"Загальний мінімальний елемент: {Math.Min(min, productB)}");
            Console.WriteLine($"Загальна сума усіх елементів: {sumA + sumB}");
            Console.WriteLine($"Загальний добуток усіх елементів: {productA * productB}");
            Console.WriteLine($"Сума парних елементів масиву A: {sumEvenA}");

            // Сума непарних стовпців масиву B
            float sumOddColumnsB = 0;
            for (int j = 0; j < B.GetLength(1); j++)
            {
                if (j % 2 != 0) // Непарні стовпці
                {
                    for (int i = 0; i < B.GetLength(0); i++)
                    {
                        sumOddColumnsB += B[i, j];
                    }
                }
            }
            Console.WriteLine($"Сума непарних стовпців масиву B: {sumOddColumnsB}");
        }
    }
}
