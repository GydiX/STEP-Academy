public class Employee
{
    public string FullName { get; set; }
    public string Position { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }

    public override string ToString()
    {
        return $"{FullName}, {Position}, {Phone}, {Email}, {Salary:C}";
    }
}

public class Firm
{
    public string Name { get; set; }
    public DateTime FoundationDate { get; set; }
    public string BusinessProfile { get; set; }
    public string Director { get; set; }
    public int EmployeeCount => Employees.Count;
    public string Address { get; set; }
    public List<Employee> Employees { get; set; } = new List<Employee>();

    public override string ToString()
    {
        return $"{Name}, {BusinessProfile}, {Director}, {EmployeeCount} employees, {Address}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення даних
        var firms = new List<Firm>
        {
            new Firm
            {
                Name = "WhiteFood",
                FoundationDate = DateTime.Now.AddYears(-3),
                BusinessProfile = "Marketing",
                Director = "John White",
                Address = "London",
                Employees = new List<Employee>
                {
                    new Employee { FullName = "Lionel Messi", Position = "Manager", Phone = "232345678", Email = "lmessi@example.com", Salary = 5000 },
                    new Employee { FullName = "Sarah Johnson", Position = "Analyst", Phone = "234567890", Email = "sjohnson@example.com", Salary = 4000 }
                }
            },
            new Firm
            {
                Name = "TechIT",
                FoundationDate = DateTime.Now.AddYears(-5),
                BusinessProfile = "IT",
                Director = "Sarah Black",
                Address = "New York",
                Employees = new List<Employee>
                {
                    new Employee { FullName = "Mike Brown", Position = "Developer", Phone = "239876543", Email = "mbrown@example.com", Salary = 6000 },
                    new Employee { FullName = "Lionel Richie", Position = "Designer", Phone = "236543210", Email = "lrichie@example.com", Salary = 4500 }
                }
            },
            new Firm
            {
                Name = "FoodLand",
                FoundationDate = DateTime.Now.AddYears(-1),
                BusinessProfile = "Food",
                Director = "Mike Green",
                Address = "London",
                Employees = new List<Employee>
                {
                    new Employee { FullName = "Emily White", Position = "Manager", Phone = "232312345", Email = "ewhite@example.com", Salary = 4700 },
                    new Employee { FullName = "Lionel Messi", Position = "Assistant", Phone = "237654321", Email = "lmessi2@example.com", Salary = 3800 }
                }
            }
        };

        // Запити
        // 1. Отримати список усіх працівників певної фірми
        var firmName = "WhiteFood";
        var employeesOfFirm = firms
            .FirstOrDefault(f => f.Name == firmName)?
            .Employees.ToList();
        PrintResults($"Employees of {firmName}:", employeesOfFirm);

        // 2. Отримати список усіх працівників певної фірми, в яких заробітна плата більша заданої
        var salaryThreshold = 4500;
        var wellPaidEmployees = firms
            .FirstOrDefault(f => f.Name == firmName)?
            .Employees
            .Where(e => e.Salary > salaryThreshold)
            .ToList();
        PrintResults($"Employees of {firmName} with salary > {salaryThreshold}:", wellPaidEmployees);

        // 3. Отримати список працівників усіх фірм, в яких є посада «Менеджер»
        var managers = firms
            .SelectMany(f => f.Employees)
            .Where(e => e.Position == "Manager")
            .ToList();
        PrintResults("All Managers:", managers);

        // 4. Отримати список працівників, в яких телефон починається з «23»
        var employeesWithPhone23 = firms
            .SelectMany(f => f.Employees)
            .Where(e => e.Phone.StartsWith("23"))
            .ToList();
        PrintResults("Employees with phone starting with '23':", employeesWithPhone23);

        // 5. Отримати список працівників, в яких Email починається з «di»
        var employeesWithEmailDi = firms
            .SelectMany(f => f.Employees)
            .Where(e => e.Email.StartsWith("di"))
            .ToList();
        PrintResults("Employees with email starting with 'di':", employeesWithEmailDi);

        // 6. Отримати список працівників з ім'ям Lionel
        var employeesNamedLionel = firms
            .SelectMany(f => f.Employees)
            .Where(e => e.FullName.Contains("Lionel"))
            .ToList();
        PrintResults("Employees named Lionel:", employeesNamedLionel);
    }

    static void PrintResults(string title, IEnumerable<Employee> results)
    {
        Console.WriteLine($"\n{title}");
        if (results == null || !results.Any())
        {
            Console.WriteLine("No results found.");
        }
        else
        {
            foreach (var result in results)
            {
                Console.WriteLine($"- {result}");
            }
        }
    }
}