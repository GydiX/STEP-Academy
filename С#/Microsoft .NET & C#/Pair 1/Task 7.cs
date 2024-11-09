Console.WriteLine("Введіть перше число діапазону:");
int first = int.Parse(Console.ReadLine());

Console.WriteLine("Введіть друге число діапазону:");
int second = int.Parse(Console.ReadLine());

if (first > second)
{
    int temp = first;
    first = second;
    second = temp;
}

Console.WriteLine("Парні числа в діапазоні:");
for (int i = first; i <= second; i++)
{
    if (i % 2 == 0)
    {
        Console.WriteLine(i);
    }
}
