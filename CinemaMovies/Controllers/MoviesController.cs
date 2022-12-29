using CinemaMovies.Adapters.Interfaces;
using CinemaMovies.DTO;
using CinemaMovies.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMovieAdapter _movieAdapter;

        public MoviesController(IMovieRepository movieRepository,
            IMovieAdapter movieAdapter)
        {
            _movieRepository = movieRepository;
            _movieAdapter = movieAdapter;
        }

        [HttpPut("toBasket")]
        public IActionResult AddMovieToBasket([FromBody]AddMovieDTO addMovie)
        {
            var item = _movieAdapter.Bind(addMovie);
            _movieRepository.Update(item);
            return Ok();
        }

        [HttpPost("review")]
        public IActionResult ReviewMovie([FromBody]MovieReviewDTO movieReviewDTO)
        {
            var movieReview = _movieAdapter.Bind(movieReviewDTO);
            _movieRepository.Create(movieReview);
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<GetMovieDTO>> GetMovies()
        {
            var movies = _movieRepository.GetAll();
            var movieDTOs = movies.Select(m => _movieAdapter.Bind(m)).ToList();
            return Ok(movieDTOs);
        }

        [HttpGet("id")]
        public ActionResult<GetMovieDTO> GetMovieById(int id)
        {
            var movie = _movieRepository.Get(id);
            var movieDTO = _movieAdapter.Bind(movie);
            return Ok(movieDTO);
        }
    }
}
