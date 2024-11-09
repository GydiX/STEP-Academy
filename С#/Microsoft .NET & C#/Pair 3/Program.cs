using System;
using System.Linq;
using System.Text;

namespace Tasks
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Завдання 1
            PrintSquare(5, '*');

            // Завдання 2
            Console.WriteLine(IsPalindrome(1221)); // true
            Console.WriteLine(IsPalindrome(7854)); // false

            // Завдання 3
            int[] originalArray = { 1, 2, 6, -1, 88, 7, 6 };
            int[] filterArray = { 6, 88, 7 };
            int[] filteredArray = FilterArray(originalArray, filterArray);
            Console.WriteLine("Filtered Array: " + string.Join(", ", filteredArray)); // 1, 2, -1

            // Завдання 4
            Website site = new Website();
            site.SetData("MySite", "www.mysite.com", "A cool site", "192.168.1.1");
            site.DisplayData();

            // Завдання 5
            Magazine mag = new Magazine();
            mag.SetData("Science Daily", 1981, "Science and Tech news", "555-1234", "info@sciencedaily.com");
            mag.DisplayData();

            // Завдання 6
            Shop shop = new Shop();
            shop.SetData("Book Haven", "123 Main St", "Book store", "555-5678", "contact@bookhaven.com");
            shop.DisplayData();
        }

        // Завдання 1: Метод для відображення квадрата з символів
        public static void PrintSquare(int sideLength, char symbol)
        {
            for (int i = 0; i < sideLength; i++)
            {
                for (int j = 0; j < sideLength; j++)
                {
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
        }

        // Завдання 2: Метод для перевірки числа на паліндром
        public static bool IsPalindrome(int number)
        {
            string numStr = number.ToString();
            string reversedStr = new string(numStr.Reverse().ToArray());
            return numStr == reversedStr;
        }

        // Завдання 3: Метод для фільтрації масиву
        public static int[] FilterArray(int[] originalArray, int[] filterArray)
        {
            return originalArray.Where(x => !filterArray.Contains(x)).ToArray();
        }
    }

    // Завдання 4: Клас «Веб-сайт»
    public class Website
    {
        public string Name { get; private set; }
        public string URL { get; private set; }
        public string Description { get; private set; }
        public string IPAddress { get; private set; }

        public void SetData(string name, string url, string description, string ipAddress)
        {
            Name = name;
            URL = url;
            Description = description;
            IPAddress = ipAddress;
        }

        public void DisplayData()
        {
            Console.WriteLine("\nWebsite Information:");
            Console.WriteLine($"Name: {Name}\nURL: {URL}\nDescription: {Description}\nIP Address: {IPAddress}");
        }
    }

    // Завдання 5: Клас «Журнал»
    public class Magazine
    {
        public string Title { get; private set; }
        public int YearFounded { get; private set; }
        public string Description { get; private set; }
        public string ContactPhone { get; private set; }
        public string Email { get; private set; }

        public void SetData(string title, int yearFounded, string description, string contactPhone, string email)
        {
            Title = title;
            YearFounded = yearFounded;
            Description = description;
            ContactPhone = contactPhone;
            Email = email;
        }

        public void DisplayData()
        {
            Console.WriteLine("\nMagazine Information:");
            Console.WriteLine($"Title: {Title}\nYear Founded: {YearFounded}\nDescription: {Description}\nContact Phone: {ContactPhone}\nEmail: {Email}");
        }
    }

    // Завдання 6: Клас «Магазин»
    public class Shop
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string ProfileDescription { get; private set; }
        public string ContactPhone { get; private set; }
        public string Email { get; private set; }

        public void SetData(string name, string address, string profileDescription, string contactPhone, string email)
        {
            Name = name;
            Address = address;
            ProfileDescription = profileDescription;
            ContactPhone = contactPhone;
            Email = email;
        }

        public void DisplayData()
        {
            Console.WriteLine("\nShop Information:");
            Console.WriteLine($"Name: {Name}\nAddress: {Address}\nProfile Description: {ProfileDescription}\nContact Phone: {ContactPhone}\nEmail: {Email}");
        }
    }
}
