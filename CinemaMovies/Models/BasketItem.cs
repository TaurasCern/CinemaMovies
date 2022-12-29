namespace CinemaMovies.Models
{
    public class BasketItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? MovieId { get; set; }
        public virtual LocalUser User { get; set; }
        public virtual Movie? Movie { get; set; }

    }
}
