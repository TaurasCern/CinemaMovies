using CinemaMovies.Models;

namespace CinemaMovies.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        void Create(BasketItem item);
        void Create(Review movieReview);
        List<Movie> GetAll();
        Movie Get(int id);
    }
}
