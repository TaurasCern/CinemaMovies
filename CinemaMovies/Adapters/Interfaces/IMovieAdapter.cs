using CinemaMovies.DTO;
using CinemaMovies.Models;

namespace CinemaMovies.Adapters.Interfaces
{
    public interface IMovieAdapter
    {
        public Basket Bind(AddMovieDTO addMovie);
    }
}
