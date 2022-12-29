using CinemaMovies.Adapters.Interfaces;
using CinemaMovies.DTO;
using CinemaMovies.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IReviewRepository _movieRepository;
        private readonly IMovieAdapter _movieAdapter;

        public MoviesController(IReviewRepository movieRepository,
            IMovieAdapter movieAdapter)
        {
            _movieRepository = movieRepository;
            _movieAdapter = movieAdapter;
        }

        [HttpPost]
        public IActionResult AddMovieToBasket(AddMovieDTO addMovie)
        {
            var item = _movieAdapter.Bind(addMovie);
            _movieRepository.Create(item);
            return Ok();
        }
    }
}
