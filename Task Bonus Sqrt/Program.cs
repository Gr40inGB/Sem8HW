// Задача со звездочкой:
// Написать функцию Sqrt(x) - квадратного корня, которая принимает на вход целочисленное значение x и возвращает целую часть квадратного корня от введенного числа.
// 4 -> 2
// 28 -> 5

// Нельзя использовать встроенные функции библиотеки Math!


int PowManual(int n)
{
    int temp = 1;
    int x = 1;
    while (n / x == 0)
    {
        x = temp * temp;
        temp++;
    }

    return x;
}


void Main()
{
    System.Console.Write("Введите число: ");
    int number = Convert.ToInt32(Console.ReadLine());

    System.Console.WriteLine(PowManual(number));
}

Main();