Console.WriteLine("Введіть число від 1 до 100:");
int num = int.Parse(Console.ReadLine());

if (num < 1 || num > 100)
{
    Console.WriteLine("Помилка: число повинно бути в діапазоні від 1 до 100");
}
else
{
    if (num % 3 == 0 && num % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }
    else if (num % 3 == 0)
    {
        Console.WriteLine("Fizz");
    }
    else if (num % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
    else
    {
        Console.WriteLine(num);
    }
}
