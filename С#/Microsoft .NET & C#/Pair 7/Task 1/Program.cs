public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Money m1 = new Money(10, 50);
            Money m2 = new Money(5, 75);

            Console.WriteLine($"m1: {m1}");
            Console.WriteLine($"m2: {m2}");

            Console.WriteLine($"m1 + m2 = {m1 + m2}");
            Console.WriteLine($"m1 - m2 = {m1 - m2}");
            Console.WriteLine($"m1 * 2 = {m1 * 2}");
            Console.WriteLine($"m1 / 2 = {m1 / 2}");

            Console.WriteLine($"m1++ = {++m1}");
            Console.WriteLine($"m2-- = {--m2}");

            Console.WriteLine($"m1 > m2: {m1 > m2}");
            Console.WriteLine($"m1 < m2: {m1 < m2}");
            Console.WriteLine($"m1 == m2: {m1 == m2}");
            Console.WriteLine($"m1 != m2: {m1 != m2}");

            // Від'ємна сума - виняток
            Money m3 = new Money(5, 0);
            Console.WriteLine($"m3 - m1 = {m3 - m1}");
        }
        catch (BankruptException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
