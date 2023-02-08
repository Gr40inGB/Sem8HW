// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:

// 1 4 7 2

// 5 9 2 3

// 8 4 2 4

// 5 2 6 7

// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка


int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}

void PrintArrayRedMin(int[,] inArray, int minRow)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        if (i == minRow)
            Console.ForegroundColor = ConsoleColor.DarkRed;

        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]}\t ");
        }
        Console.ForegroundColor = ConsoleColor.White;


        Console.WriteLine();
    }
}

int[] SummOfRowInArray(int[,] array)
{
    int[] summArray = new int[array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int summ = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            summ += array[i, j];
        }
        summArray[i] = summ;
    }
    return summArray;
}

int minInArray(int[] array)
{
    int minIndex = 0;
    for (int i = 1; i < array.Length; i++)
    {
        if (array[minIndex] > array[i])
        {
            minIndex = i;
        }
    }
    return minIndex;
}


void Main()
{
    Console.Clear();
    Console.Write("Введите кол-во строк: ");
    int row = int.Parse(Console.ReadLine()!);
    Console.Write("Введите кол-во столбцов: ");
    int col = int.Parse(Console.ReadLine()!);
    int[,] ourArray = GetArray(row, col, 1, 9);
    System.Console.WriteLine();
    int minSummRowIndex = minInArray(SummOfRowInArray(ourArray));
    PrintArrayRedMin(ourArray, minSummRowIndex);
    System.Console.WriteLine($"\nНомер строки с наименьшей суммой элементов: {minSummRowIndex + 1}");
}

Main();