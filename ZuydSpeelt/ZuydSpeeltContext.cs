using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ZuydSpeelt
{
    public class ZuydSpeeltContext : DbContext
    {
        // Making it possible to read the connectionstring from the appsettings.json file, in the future easier to change
        private readonly IConfiguration Configuration;
        public ZuydSpeeltContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<Category> Category { get; set; } = null!;
        public DbSet<Comment> Comment { get; set; } = null!;
        public DbSet<Game> Game { get; set; } = null!;
        public DbSet<Rating> Rating { get; set; } = null!;
        public DbSet<User> User { get; set; } = null!;
        public DbSet<UserGame> UserGame { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("ZUYDSPEELT_CONNECTIONSTRING"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    Username = "test",
                    Password = "password",
                    Email = "test@gmail.com",
                    CreatedAt = new DateTime(2023, 02, 02, 0, 0, 0, DateTimeKind.Utc)
                });

            modelBuilder.Entity<Category>()
                .HasData(new Category
                {
                    Id = 1,
                    Name = "action"
                });

            modelBuilder.Entity<Game>()
                .HasData(new Game
                {
                    Id = 1,
                    Title = "TestGame",
                    CreatedAt = new DateTime(2023, 02, 02, 0, 0, 0, DateTimeKind.Utc),
                    Popularity = 0,
                    CategoryId = 1
                });
            modelBuilder.Entity<UserGame>()
                .HasData(new UserGame
                {
                    UserId = 1,
                    GameId = 1,
                    CreatedAt = new DateTime(2023, 02, 02, 0, 0, 0, DateTimeKind.Utc),
                    Score = 5
                });
            modelBuilder.Entity<Comment>()
                .HasData(new Comment
                {
                    Id = 1,
                    UserId = 1,
                    GameId = 1,
                    Text = "Dit is een leuk spel",
                    CreatedAt = new DateTime(2023, 02, 02, 0, 0, 0, DateTimeKind.Utc)
                });
            modelBuilder.Entity<Rating>()
                .HasData(new Rating
                {
                    Id = 1,
                    UserId = 1,
                    GameId = 1,
                    Value = 5
                });
            modelBuilder.Entity<UserGame>().HasKey(e => new { e.UserId, e.GameId, e.CreatedAt });

            // Ignoring these to prevent double tables in this many to many relationship
            modelBuilder.Entity<User>().Ignore(e => e.Games);
            modelBuilder.Entity<Game>().Ignore(e => e.Users);
        }
    }
}
