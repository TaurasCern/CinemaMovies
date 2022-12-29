
using CinemaMovies.DTO;
using CinemaMovies.Models;

namespace CinemaMovies.Repositories.Interfaces
{
    public interface ILocalUserRepository
    {
        public Task<bool> IsUniqueUserAsync(string email);
        public Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
        public Task<LocalUser> RegisterAsync(RegistrationRequest registrationRequest);
    }
}
