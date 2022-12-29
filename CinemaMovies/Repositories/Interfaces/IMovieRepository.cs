using CinemaMovies.Models;

namespace CinemaMovies.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        void Update(Basket basket);
        void Create(Review movieReview);
        List<Movie> GetAll();
        Movie Get(int id);
    }
}
