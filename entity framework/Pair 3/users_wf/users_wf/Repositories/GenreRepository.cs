using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using users_wf.Models;

namespace users_wf.Repositories
{
    public class GenreRepository
    {
        private readonly AppDbContext _context;

        public GenreRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddGenreAsync(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGenreAsync(Genre genre)
        {
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGenreAsync(string id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Genre>> GetAllGenresAsync()
        {
            return await _context.Genres.Include(g => g.Movies).ToListAsync();
        }

        public async Task<List<Genre>> GetGenresWithMovieCountAsync()
        {
            return await _context.Genres
                .Select(g => new Genre
                {
                    Id = g.Id,
                    Name = g.Name,
                    Movies = g.Movies
                })
                .ToListAsync();
        }
    }
}