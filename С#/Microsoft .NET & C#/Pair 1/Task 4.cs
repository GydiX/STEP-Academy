Console.WriteLine("Введіть шестизначне число:");
string sixDigitNumber = Console.ReadLine();

if (sixDigitNumber.Length != 6)
{
    Console.WriteLine("Помилка: число повинно бути шестизначним");
}
else
{
    Console.WriteLine("Введіть перший номер для заміни:");
    int pos1 = int.Parse(Console.ReadLine()) - 1;

    Console.WriteLine("Введіть другий номер для заміни:");
    int pos2 = int.Parse(Console.ReadLine()) - 1;

    char[] digits = sixDigitNumber.ToCharArray();

    // міняємо цифри місцями
    char temp = digits[pos1];
    digits[pos1] = digits[pos2];
    digits[pos2] = temp;

    string result = new string(digits);
    Console.WriteLine("Результат: " + result);
}
