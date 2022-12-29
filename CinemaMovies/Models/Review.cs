namespace CinemaMovies.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public LocalUser User;
        public int MovieId { get; set; }
        public Movie Movie;
    }
}
