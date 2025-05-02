using System;

namespace VideoGameStore
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoGameStoreService service = new VideoGameStoreService();

            // Тестування методів для "Розробники"
            var developer = new Developer { Name = "Epic Games", EstablishedDate = new DateTime(1991, 1, 1) };
            service.AddDeveloper(developer);

            var developers = service.GetAllDevelopers();
            Console.WriteLine("Всі розробники:");
            foreach (var dev in developers)
            {
                Console.WriteLine($"ID: {dev.Id}, Назва: {dev.Name}, Дата заснування: {dev.EstablishedDate}");
            }

            // Оновлення розробника
            developer.Name = "Epic Games Updated";
            service.UpdateDeveloper(developer);

            // Отримання розробника по назві
            var foundDev = service.GetDeveloperByName("Epic Games Updated");
            Console.WriteLine($"Знайдений розробник: {foundDev.Name}");

            // Видалення розробника
            service.RemoveDeveloper(foundDev.Id);

            // Тестування методів для "Ігри"
            var game = new Game { Title = "Fortnite", Price = 0, IsMultiplayer = true, DeveloperId = developer.Id };
            service.AddGame(game);

            var gamesInRange = service.GetGamesByPriceRange(0, 60);
            Console.WriteLine("Ігри у вказаному ціновому діапазоні:");
            foreach (var g in gamesInRange)
            {
                Console.WriteLine($"Назва: {g.Title}, Ціна: {g.Price}");
            }

            var multiplayerGames = service.GetMultiplayerGames();
            Console.WriteLine("Багатокористувацькі ігри:");
            foreach (var g in multiplayerGames)
            {
                Console.WriteLine($"Назва: {g.Title}");
            }
        }
    }
}