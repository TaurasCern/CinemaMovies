namespace CinemaMovies.Models
{
    public class BasketItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? MovieId { get; set; }
        public int? TicketTypeId { get; set; }
        public int? FoodId { get; set; }
        public decimal Price { get; set; }
        public virtual LocalUser User { get; set; }
        public virtual Movie? Movie { get; set; }
        public virtual TicketType? TicketType { get; set; }
        public virtual Food? Food { get; set; }

    }
}
