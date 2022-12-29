using CinemaMovies.Enums;

namespace CinemaMovies.DTO
{
    public class AddMovieDTO
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public ETicketType Type { get; set; }
    }
}