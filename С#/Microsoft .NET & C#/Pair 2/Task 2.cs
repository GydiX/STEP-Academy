using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[,] matrix = new int[5, 5];

            // Заповнення матриці випадковими числами
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(-100, 101);
                }
            }

            // Виведення матриці
            Console.WriteLine("Матриця:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // Пошук мінімального і максимального значення
            int minValue = matrix[0, 0];
            int maxValue = matrix[0, 0];
            int minRow = 0, minCol = 0, maxRow = 0, maxCol = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < minValue)
                    {
                        minValue = matrix[i, j];
                        minRow = i;
                        minCol = j;
                    }
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            // Обчислення суми елементів між мінімальним і максимальним
            int sum = 0;
            int startRow = Math.Min(minRow, maxRow);
            int endRow = Math.Max(minRow, maxRow);
            int startCol = Math.Min(minCol, maxCol);
            int endCol = Math.Max(minCol, maxCol);

            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startCol; j <= endCol; j++)
                {
                    sum += matrix[i, j];
                }
            }

            Console.WriteLine($"Сума елементів між мінімальним ({minValue}) і максимальним ({maxValue}): {sum}");
        }
    }
}
