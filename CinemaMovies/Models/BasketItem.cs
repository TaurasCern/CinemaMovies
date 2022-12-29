namespace CinemaMovies.Models
{
    public class BasketItem
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int? movieId { get; set; }
        public virtual User User { get; set; }
        public virtual Movie? Movie { get; set; }

    }
}
