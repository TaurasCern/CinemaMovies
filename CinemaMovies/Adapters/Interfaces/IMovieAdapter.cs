using CinemaMovies.DTO;
using CinemaMovies.Models;

namespace CinemaMovies.Adapters.Interfaces
{
    public interface IMovieAdapter
    {
        public BasketItem Bind(AddMovieDTO addMovie);
    }
}
