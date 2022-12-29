namespace CinemaMovies.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public int Title { get; set; }
        public int Description { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}