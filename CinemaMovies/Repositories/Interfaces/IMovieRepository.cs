
using CinemaMovies.Models;

namespace CinemaMovies.Repositories.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<Movie> UpdateAsync(Movie movie);
        Task<bool> ExistAsync(int id);
        Task Update(Basket basket);
        Task Create(Review movieReview);
        Task<List<Movie>> GetAll();
        Task<Movie> Get(int id);
    }
}
