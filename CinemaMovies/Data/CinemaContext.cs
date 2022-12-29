using CinemaMovies.Enums;
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
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Local user
            modelBuilder.Entity<LocalUser>()
                .HasKey(u => u.UserId);
            modelBuilder.Entity<LocalUser>()
                .HasOne(u => u.Basket)
                .WithOne(b => b.LocalUser)
                .HasForeignKey<Basket>(b => b.UserId);
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
            // FoodItem
            modelBuilder.Entity<FoodItem>()
                .HasKey(r => r.FoodItemId);
            // Basket
            modelBuilder.Entity<Basket>()
                .HasKey(b => b.BasketId);
            modelBuilder.Entity<Basket>()
                .HasOne(b => b.LocalUser)
                .WithOne(u => u.Basket)
                .HasForeignKey<LocalUser>(u => u.BasketId);
            // Tickets
            modelBuilder.Entity<Ticket>()
                .HasKey(r => r.TicketId);
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Movie)
                .WithMany(m => m.Tickets)
                .HasForeignKey(t => t.MovieId);
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Basket)
                .WithMany(b => b.Tickets)
                .HasForeignKey(t => t.BasketId);
            modelBuilder.Entity<Ticket>()
                .Property(t => t.Type)
                .HasConversion(
                    t => t.ToString(),
                    t => (ETicketType)Enum.Parse(typeof(ETicketType), t));
            // FoodItem
            modelBuilder.Entity<FoodItem>()
                .HasKey(f => f.FoodItemId);
            // BasketFood
            modelBuilder.Entity<BasketFood>()
                .HasKey(bf => bf.BasketFoodId);
            modelBuilder.Entity<BasketFood>()
                .HasOne(bf => bf.Basket)
                .WithMany(m => m.BasketFoods)
                .HasForeignKey(t => t.BasketId);
            modelBuilder.Entity<BasketFood>()
                .HasOne(t => t.FoodItem)
                .WithMany(b => b.BasketFoods)
                .HasForeignKey(t => t.FoodItemId);
        }
    }   
}
