namespace CinemaMovies.Models
{
    public class LocalUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public int BasketId { get; set; }
        public Basket Basket { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
