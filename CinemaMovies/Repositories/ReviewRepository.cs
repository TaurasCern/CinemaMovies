using CinemaMovies.Data;
using CinemaMovies.Models;
using CinemaMovies.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaMovies.Repositories
{
    public class ReviewRepository : Repository<Movie>, IMovieRepository
    {
        private readonly CinemaContext _db;

        public ReviewRepository(CinemaContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _db.Movies.AnyAsync(x => x.MovieId == id);
        }

        public async Task<Movie> UpdateAsync(Movie movie)
        {
            _db.Movies.Update(movie);
            await _db.SaveChangesAsync();

            return movie;
        }
    }
}
