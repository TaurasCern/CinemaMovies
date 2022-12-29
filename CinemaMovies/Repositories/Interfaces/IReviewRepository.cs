
using CinemaMovies.Models;

namespace CinemaMovies.Repositories.Interfaces
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<Review> UpdateAsync(Review review);
        Task<bool> ExistAsync(int id);


    }
}
