using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using users_wf.Models;

namespace users_wf.Repositories
{
    public class MovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddMovieAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(string id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.Include(m => m.Genre).ToListAsync();
        }

        public async Task<List<Movie>> GetMoviesByGenreAsync(string genreId)
        {
            return await _context.Movies.Where(m => m.GenreId == genreId).ToListAsync();
        }

        public async Task<List<Movie>> GetLatestMoviesAsync()
        {
            return await _context.Movies.Where(m => m.ReleaseDate >= DateTime.Now.AddYears(-5)).ToListAsync();
        }

        public async Task<List<Movie>> SearchMoviesByTitleAsync(string keyword)
        {
            return await _context.Movies.Where(m => m.Title.Contains(keyword)).ToListAsync();
        }
    }
}