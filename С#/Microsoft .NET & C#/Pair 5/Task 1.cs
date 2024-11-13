namespace MagazineNamespace
{
    public class Journal
    {
        // Властивості класу
        public string Title { get; set; }
        public int FoundingYear { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        
        private int employees;
        public int Employees
        {
            get => employees;
            set => employees = value < 0 ? 0 : value; // Обмеження для кількості працівників
        }

        // Конструктор
        public Journal(string title, int foundingYear, string description, string phone, string email, int employees)
        {
            Title = title;
            FoundingYear = foundingYear;
            Description = description;
            Phone = phone;
            Email = email;
            Employees = employees;
        }

        // Метод введення даних
        public void EnterData(string title, int foundingYear, string description, string phone, string email, int employees)
        {
            Title = title;
            FoundingYear = foundingYear;
            Description = description;
            Phone = phone;
            Email = email;
            Employees = employees;
        }

        // Метод виведення даних
        public void PrintData()
        {
            Console.WriteLine($"Назва журналу: {Title}\nРік заснування: {FoundingYear}\nОпис: {Description}\nТелефон: {Phone}\nEmail: {Email}\nПрацівників: {Employees}");
        }

        // Перевантаження оператора +
        public static Journal operator +(Journal journal, int additionalEmployees)
        {
            journal.Employees += additionalEmployees;
            return journal;
        }

        // Перевантаження оператора -
        public static Journal operator -(Journal journal, int reductionEmployees)
        {
            journal.Employees -= reductionEmployees;
            return journal;
        }

        // Перевантаження операторів порівняння
        public static bool operator ==(Journal j1, Journal j2)
        {
            return j1.Employees == j2.Employees;
        }

        public static bool operator !=(Journal j1, Journal j2)
        {
            return j1.Employees != j2.Employees;
        }

        public static bool operator <(Journal j1, Journal j2)
        {
            return j1.Employees < j2.Employees;
        }

        public static bool operator >(Journal j1, Journal j2)
        {
            return j1.Employees > j2.Employees;
        }

        public static bool operator <=(Journal j1, Journal j2)
        {
            return j1.Employees <= j2.Employees;
        }

        public static bool operator >=(Journal j1, Journal j2)
        {
            return j1.Employees >= j2.Employees;
        }

        // Переопределение Equals и GetHashCode для корректного сравнения объектов
        public override bool Equals(object? obj) => obj is Journal journal && this == journal;
        public override int GetHashCode() => Employees.GetHashCode();
    }
}
