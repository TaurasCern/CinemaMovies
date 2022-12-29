using CinemaMovies.Enums;

namespace CinemaMovies.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public double Price { get; set; }
        public ETicketType Type { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
    }
}
