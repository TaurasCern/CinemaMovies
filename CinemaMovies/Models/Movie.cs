namespace CinemaMovies.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}