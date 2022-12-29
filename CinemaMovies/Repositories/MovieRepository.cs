using CinemaMovies.Data;
using CinemaMovies.Models;
using CinemaMovies.Repositories;
using CinemaMovies.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_mokymai.Repository
{
    public class ReviewRepository: Repository<Review>, IReviewRepository
    {
        private readonly CinemaContext _db;

        public ReviewRepository(CinemaContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _db.Reviews.AnyAsync(x => x.ReviewId == id);
        }

        public async Task<Review> UpdateAsync(Review review)
        {
            _db.Reviews.Update(review);
            await _db.SaveChangesAsync();

            return review;
        }
    }
}
