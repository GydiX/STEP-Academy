namespace MoneyProductApp
{
    public class Money
    {
        public int WholePart { get; set; }  // Ціла частина (долари, гривні тощо)
        public int Cents { get; set; }      // Копійки або центи

        public Money(int wholePart, int cents)
        {
            WholePart = wholePart;
            Cents = cents;
        }

        public void Display()
        {
            Console.WriteLine($"{WholePart}.{Cents:D2}");
        }

        public void SetValues(int wholePart, int cents)
        {
            WholePart = wholePart;
            Cents = cents;
        }
    }

    public class Product : Money
    {
        public string Name { get; set; }

        public Product(string name, int wholePart, int cents) : base(wholePart, cents)
        {
            Name = name;
        }

        public void DecreasePrice(int amount)
        {
            int totalCents = WholePart * 100 + Cents - amount;
            WholePart = totalCents / 100;
            Cents = totalCents % 100;
        }

        public void DisplayPrice()
        {
            Console.Write($"{Name} costs ");
            Display();
        }
    }

    class Program
    {
        static void Main()
        {
            Product product = new Product("Laptop", 599, 99);
            product.DisplayPrice();
            product.DecreasePrice(150);
            Console.WriteLine("After discount:");
            product.DisplayPrice();
        }
    }
}
