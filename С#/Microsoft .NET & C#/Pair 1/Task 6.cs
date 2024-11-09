Console.WriteLine("Введіть температуру:");
double temperature = double.Parse(Console.ReadLine());

Console.WriteLine("Введіть одиниці виміру (C/F):");
string unit = Console.ReadLine().ToUpper();

if (unit == "C")
{
    double fahrenheit = (temperature * 9 / 5) + 32;
    Console.WriteLine($"{temperature}°C = {fahrenheit}°F");
}
else if (unit == "F")
{
    double celsius = (temperature - 32) * 5 / 9;
    Console.WriteLine($"{temperature}°F = {celsius}°C");
}
else
{
    Console.WriteLine("Невірна одиниця виміру");
}
