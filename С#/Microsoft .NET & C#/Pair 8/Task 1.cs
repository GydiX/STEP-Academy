using System;
using System.Collections.Generic;

public class EmployeeManager
{
    private Dictionary<string, string> employees = new Dictionary<string, string>();

    public void AddEmployee(string login, string password)
    {
        if (!employees.ContainsKey(login))
        {
            employees[login] = password;
            Console.WriteLine($"Співробітника {login} додано.");
        }
        else
        {
            Console.WriteLine("Такий логін вже існує.");
        }
    }

    public void RemoveEmployee(string login)
    {
        if (employees.Remove(login))
        {
            Console.WriteLine($"Співробітника {login} видалено.");
        }
        else
        {
            Console.WriteLine("Логін не знайдено.");
        }
    }

    public void UpdateEmployee(string login, string newPassword)
    {
        if (employees.ContainsKey(login))
        {
            employees[login] = newPassword;
            Console.WriteLine($"Пароль для {login} оновлено.");
        }
        else
        {
            Console.WriteLine("Логін не знайдено.");
        }
    }

    public void GetPassword(string login)
    {
        if (employees.TryGetValue(login, out string password))
        {
            Console.WriteLine($"Пароль для {login}: {password}");
        }
        else
        {
            Console.WriteLine("Логін не знайдено.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        EmployeeManager manager = new EmployeeManager();
        manager.AddEmployee("john_doe", "password123");
        manager.AddEmployee("jane_smith", "securepass");

        manager.GetPassword("john_doe");
        manager.UpdateEmployee("john_doe", "newpassword123");
        manager.GetPassword("john_doe");

        manager.RemoveEmployee("jane_smith");
        manager.GetPassword("jane_smith");
    }
}
