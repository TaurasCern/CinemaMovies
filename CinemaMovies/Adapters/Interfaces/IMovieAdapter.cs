using CinemaMovies.DTO;
using CinemaMovies.Models;

namespace CinemaMovies.Adapters.Interfaces
{
    public interface IMovieAdapter
    {
        BasketItem Bind(AddMovieDTO addMovie);
        MovieReview Bind(MovieReviewDTO movieReviewDTO);
        GetMovieDTO Bind(Movie m);
    }
}
