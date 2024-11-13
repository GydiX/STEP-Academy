namespace StoreNamespace
{
    public class Store
    {
        // Властивості класу
        public string Name { get; set; }
        public string Address { get; set; }
        public string ProfileDescription { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        
        private double area;
        public double Area
        {
            get => area;
            set => area = value < 0 ? 0 : value; // Обмеження для площі магазину
        }

        // Конструктор
        public Store(string name, string address, string profileDescription, string phone, string email, double area)
        {
            Name = name;
            Address = address;
            ProfileDescription = profileDescription;
            Phone = phone;
            Email = email;
            Area = area;
        }

        // Метод введення даних
        public void EnterData(string name, string address, string profileDescription, string phone, string email, double area)
        {
            Name = name;
            Address = address;
            ProfileDescription = profileDescription;
            Phone = phone;
            Email = email;
            Area = area;
        }

        // Метод виведення даних
        public void PrintData()
        {
            Console.WriteLine($"Назва магазину: {Name}\nАдреса: {Address}\nОпис профілю: {ProfileDescription}\nТелефон: {Phone}\nEmail: {Email}\nПлоща: {Area} кв.м.");
        }

        // Перевантаження оператора +
        public static Store operator +(Store store, double additionalArea)
        {
            store.Area += additionalArea;
            return store;
        }

        // Перевантаження оператора -
        public static Store operator -(Store store, double reductionArea)
        {
            store.Area -= reductionArea;
            return store;
        }

        // Перевантаження операторів порівняння
        public static bool operator ==(Store s1, Store s2)
        {
            return s1.Area == s2.Area;
        }

        public static bool operator !=(Store s1, Store s2)
        {
            return s1.Area != s2.Area;
        }

        public static bool operator <(Store s1, Store s2)
        {
            return s1.Area < s2.Area;
        }

        public static bool operator >(Store s1, Store s2)
        {
            return s1.Area > s2.Area;
        }

        public static bool operator <=(Store s1, Store s2)
        {
            return s1.Area <= s2.Area;
        }

        public static bool operator >=(Store s1, Store s2)
        {
            return s1.Area >= s2.Area;
        }

        // Переопределение Equals и GetHashCode для корректного сравнения объектов
        public override bool Equals(object? obj) => obj is Store store && this == store;
        public override int GetHashCode() => Area.GetHashCode();
    }
}
