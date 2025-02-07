using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore
{
    public class VideoGameStoreService
    {
        private VideoGameStoreContext _context;

        public VideoGameStoreService()
        {
            _context = new VideoGameStoreContext();
        }

        // Методи для таблиці "Розробники"
        public void AddDeveloper(Developer developer)
        {
            _context.Developers.Add(developer);
            _context.SaveChanges();
        }

        public void RemoveDeveloper(int id)
        {
            var developer = _context.Developers.Find(id);
            if (developer != null)
            {
                _context.Developers.Remove(developer);
                _context.SaveChanges();
            }
        }

        public void UpdateDeveloper(Developer developer)
        {
            _context.Entry(developer).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Developer> GetAllDevelopers()
        {
            return _context.Developers.ToList();
        }

        public Developer GetDeveloperByName(string name)
        {
            return _context.Developers.FirstOrDefault(d => d.Name == name);
        }

        public Developer GetDeveloperById(int id)
        {
            return _context.Developers.Find(id);
        }

        public List<Developer> GetDevelopersByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.Developers.Where(d => d.EstablishedDate >= startDate && d.EstablishedDate <= endDate).ToList();
        }

        // Методи для таблиці "Ігри"
        public List<Game> GetGamesByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _context.Games.Where(g => g.Price >= minPrice && g.Price <= maxPrice).ToList();
        }

        public Game GetGameByTitle(string title)
        {
            return _context.Games.FirstOrDefault(g => g.Title == title);
        }

        public List<Game> GetMultiplayerGames()
        {
            return _context.Games.Where(g => g.IsMultiplayer).ToList();
        }
    }
}
