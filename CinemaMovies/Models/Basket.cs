namespace CinemaMovies.Models
{
    public class Basket
    {
        public int BasketId { get; set; }
        public int UserId { get; set; }
        public LocalUser LocalUser { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<BasketFood> BasketFoods { get; set; }
    }
}
