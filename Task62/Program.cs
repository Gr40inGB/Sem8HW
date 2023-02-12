// Задача со звездочкой. Напишите программу, 
// которая реализует обход введенного двумерного массива, 
// начиная с крайнего нижнего левого элемента против часовой стрелки.

// 1 2 3
// 4 5 6 -> 7 8 9 6 3 2 1 4 5
// 7 8 9

void PrintArray(int[,,] inArray)
{
    int currentColour = 0;
    Random randomazer = new Random();

    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            currentColour = inArray[i, j, 1];

            if (currentColour == 1)
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            else if (currentColour == 1)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (currentColour == 2)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else if (currentColour == 3)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (currentColour == 4)
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            else if (currentColour == 5)
                Console.ForegroundColor = ConsoleColor.Blue;
            else if (currentColour == 6)
                Console.ForegroundColor = ConsoleColor.DarkGray;
            else if (currentColour == 7)
                Console.ForegroundColor = ConsoleColor.White;
            else if (currentColour == 8)
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            else if (currentColour == 9)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (currentColour == 10)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (currentColour == 11)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else if (currentColour == 12)
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            else if (currentColour == 13)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (currentColour == 14)
                Console.ForegroundColor = ConsoleColor.Green;

            Console.Write($"{inArray[i, j, 0]:F0}\t ");
        }

        System.Console.WriteLine("\n");
    }
    Console.ForegroundColor = ConsoleColor.White;

}

void turnRight(int[] nowSpArray)//int ys, int xs)
{
    int xs = nowSpArray[1]; // speed horizontally
    int ys = nowSpArray[0]; // speed vertically
    if (ys == -1 && xs == 0)
    { ys = 0; xs = 1; }     //вправо
    else if (ys == 0 && xs == 1)
    { ys = 1; xs = 0; }     // вниз
    else if (ys == 1 && xs == 0)
    { ys = 0; xs = -1; }    //влево 
    else if (ys == 0 && xs == -1)
    { ys = -1; xs = 0; }    //вверх
    nowSpArray[1] = xs;
    nowSpArray[0] = ys;
}

void SnakeTrack(int[,,] arrayForSpiral)   // проходим по нижней строке слева направо - записываем все значения
{
    int hight = arrayForSpiral.GetLength(0);
    int width = arrayForSpiral.GetLength(1);
    int rowIndex = 0;
    int columnIndex = 0;

    int[] nowSpeed = new int[2] { 0, 1 }; // сначала движемся вправо
    int ySpeed, xSpeed;

    int forColor = 0;
    arrayForSpiral[0, 0, 0] = 1;
    int trackNumber = 2;


    while (trackNumber <= arrayForSpiral.Length / 2)
    {
        ySpeed = nowSpeed[0];   // скорость по вертикали
        xSpeed = nowSpeed[1];   // скорость по горизонтали

        if (ySpeed == 0)
        {
            if ((columnIndex == width - 1 && xSpeed > 0) || (columnIndex == 0 && xSpeed < 0))
            {
                turnRight(nowSpeed); forColor++;
            }
            else
            {
                if (arrayForSpiral[rowIndex + ySpeed, columnIndex + xSpeed, 0] == 0)
                {
                    columnIndex += xSpeed;
                    arrayForSpiral[rowIndex, columnIndex, 0] = trackNumber++;
                    arrayForSpiral[rowIndex, columnIndex, 1] = forColor;
                }
                else
                {
                    turnRight(nowSpeed); forColor++;
                }
            }
        }
        else if (xSpeed == 0)
        {
            if ((rowIndex == hight - 1 && ySpeed > 0) || (rowIndex == 0 && ySpeed < 0))
            {
                turnRight(nowSpeed); forColor++;
            }
            else
            {
                if (arrayForSpiral[rowIndex + ySpeed, columnIndex + xSpeed, 0] == 0)
                {
                    rowIndex += ySpeed;
                    arrayForSpiral[rowIndex, columnIndex, 0] = trackNumber++;
                    arrayForSpiral[rowIndex, columnIndex, 1] = forColor;
                }
                else
                {
                    turnRight(nowSpeed); forColor++;
                }
            }
        }
    }
}

void Main()
{
    Console.Clear();
    Random randomSize = new Random();
    int[,,] ourArray = new int[randomSize.Next(6, 8), randomSize.Next(5, 8), 2];
    SnakeTrack(ourArray);
    PrintArray(ourArray);
}

Main();