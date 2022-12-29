namespace CinemaMovies.Models
{
    public class LoginResponse
    {
        public LocalUser? Localuser { get; set; }
        public string Token { get; set; }

    }
}
