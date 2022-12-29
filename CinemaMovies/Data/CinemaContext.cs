using CinemaMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaMovies.Data
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> options)
            : base(options)
        {

        }

        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Local user
            modelBuilder.Entity<LocalUser>()
                .HasKey(u => u.UserId);
            // Movie
            modelBuilder.Entity<Movie>()
                .HasKey(m => m.MovieId);
            // Review
            modelBuilder.Entity<Review>()
                .HasKey(r => r.ReviewId);
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Movie)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.MovieId);
        }
    }   
}
