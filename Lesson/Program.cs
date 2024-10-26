using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int[,] matrix = new int[9, 9];
        if (FillMatrix(matrix, 0, 0))
            PrintMatrix(matrix);
    }

    static void PrintMatrix(int[,] matrix)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
                if (j % 3 == 2 && j < 6) Console.Write(" | ");
            }
            Console.WriteLine();
            if (i % 3 == 2 && i < 6) Console.WriteLine(new string('-', 23));
        }
        Console.WriteLine();
        Console.ResetColor();
    }

    static bool IsValid(int[,] matrix, int item, int row, int column)
    {
        for (int i = 0; i < 9; i++)
        {
            if (matrix[row, i] == item || matrix[i, column] == item)
                return false;
        }

        int startRow = (row / 3) * 3;
        int startCol = (column / 3) * 3;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (matrix[startRow + i, startCol + j] == item)
                    return false;
            }
        }

        return true;
    }

    static bool FillMatrix(int[,] matrix, int row, int col)
    {
        if (row == 9)
            return true;

        if (col == 9)
            return FillMatrix(matrix, row + 1, 0);

        List<int> numbers = Enumerable.Range(1, 9).OrderBy(n => Guid.NewGuid()).ToList();

        foreach (int num in numbers)
        {
            if (IsValid(matrix, num, row, col))
            {
                matrix[row, col] = num;

                if (FillMatrix(matrix, row, col + 1))
                    return true;

                matrix[row, col] = 0;
            }
        }

        return false;
    }
}