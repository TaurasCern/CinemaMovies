using CinemaMovies.Models;

namespace CinemaMovies.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        void Create(Basket item);
        void Create(Review movieReview);
        List<Movie> GetAll();
        Movie Get(int id);
    }
}
