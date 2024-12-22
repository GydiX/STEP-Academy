public class Firm
{
    public string Name { get; set; }
    public DateTime FoundationDate { get; set; }
    public string BusinessProfile { get; set; }
    public string Director { get; set; }
    public int EmployeeCount { get; set; }
    public string Address { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var firms = new List<Firm>
        {
            new Firm { Name = "WhiteFood", FoundationDate = DateTime.Now.AddYears(-3), BusinessProfile = "Marketing", Director = "John White", EmployeeCount = 250, Address = "London" },
            new Firm { Name = "TechIT", FoundationDate = DateTime.Now.AddYears(-5), BusinessProfile = "IT", Director = "Sarah Black", EmployeeCount = 500, Address = "New York" },
            new Firm { Name = "FoodLand", FoundationDate = DateTime.Now.AddYears(-1), BusinessProfile = "Food", Director = "Mike Green", EmployeeCount = 120, Address = "London" },
            new Firm { Name = "MarketStars", FoundationDate = DateTime.Now.AddYears(-4), BusinessProfile = "Marketing", Director = "David Smith", EmployeeCount = 80, Address = "Paris" },
        };

        // 1. Отримати інформацію про всі фірми
        var allFirms = firms.ToList();

        // 2. Отримати фірми, які мають у назві слово «Food»
        var foodFirms = firms.Where(f => f.Name.Contains("Food")).ToList();

        // 3. Отримати фірми, які працюють у галузі маркетингу
        var marketingFirms = firms.Where(f => f.BusinessProfile == "Marketing").ToList();

        // 4. Отримати фірми, які працюють у галузі маркетингу або IT
        var marketingOrITFirms = firms.Where(f => f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT").ToList();

        // 5. Отримати фірми з кількістю працівників більшою, ніж 100
        var firmsWithLargeStaff = firms.Where(f => f.EmployeeCount > 100).ToList();

        // 6. Отримати фірми з кількістю працівників у діапазоні від 100 до 300
        var firmsInRange = firms.Where(f => f.EmployeeCount >= 100 && f.EmployeeCount <= 300).ToList();

        // 7. Отримати фірми, які знаходяться в Лондоні
        var londonFirms = firms.Where(f => f.Address == "London").ToList();

        // 8. Отримати фірми, в яких прізвище директора White
        var firmsWithDirectorWhite = firms.Where(f => f.Director.Split(' ').Last() == "White").ToList();

        // 9. Отримати фірми, які засновані більше двох років тому
        var olderFirms = firms.Where(f => (DateTime.Now - f.FoundationDate).Days > 2 * 365).ToList();

        // 10. Отримати фірми з дня заснування яких минуло 123 дні
        var firms123DaysOld = firms.Where(f => (DateTime.Now - f.FoundationDate).Days == 123).ToList();

        // 11. Отримати фірми, в яких прізвище директора Black і мають у назві фірми слово «White»
        var blackWhiteFirms = firms.Where(f => f.Director.Split(' ').Last() == "Black" && f.Name.Contains("White")).ToList();

        PrintResults("All firms", allFirms);
        PrintResults("Firms with 'Food' in the name", foodFirms);
        PrintResults("Marketing firms", marketingFirms);
        PrintResults("Marketing or IT firms", marketingOrITFirms);
        PrintResults("Firms with >100 employees", firmsWithLargeStaff);
        PrintResults("Firms with 100-300 employees", firmsInRange);
        PrintResults("Firms in London", londonFirms);
        PrintResults("Firms with director White", firmsWithDirectorWhite);
        PrintResults("Firms older than 2 years", olderFirms);
        PrintResults("Firms 123 days old", firms123DaysOld);
        PrintResults("Firms with director Black and 'White' in name", blackWhiteFirms);
    }

    static void PrintResults(string title, IEnumerable<Firm> results)
    {
        Console.WriteLine($"\n{title}:");
        foreach (var result in results)
        {
            Console.WriteLine($"- {result.Name}, {result.BusinessProfile}, {result.Director}, {result.EmployeeCount} employees");
        }
    }
}
