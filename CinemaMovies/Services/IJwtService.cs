namespace CinemaMovies
{
    public interface IJwtService
    {
        string GetJwtToken(string email, int roleId);
    }
}