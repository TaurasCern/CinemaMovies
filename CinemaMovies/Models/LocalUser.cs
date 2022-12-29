namespace CinemaMovies.Models
{
    public class LocalUser
    {
        public int UserId { get; set; }
        public int Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
