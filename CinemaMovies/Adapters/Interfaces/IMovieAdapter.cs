using CinemaMovies.DTO;
using CinemaMovies.Models;

namespace CinemaMovies.Adapters.Interfaces
{
    public interface IMovieAdapter
    {
        Basket Bind(AddMovieDTO addMovie);
        Review Bind(MovieReviewDTO movieReviewDTO);
        GetMovieDTO Bind(Movie movie);
    }
}
