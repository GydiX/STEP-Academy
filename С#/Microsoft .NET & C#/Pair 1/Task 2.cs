Console.WriteLine("Введіть число:");
double number = double.Parse(Console.ReadLine());

Console.WriteLine("Введіть відсоток:");
double percent = double.Parse(Console.ReadLine());

double result = number * percent / 100;
Console.WriteLine($"{percent}% від {number} дорівнює {result}");
