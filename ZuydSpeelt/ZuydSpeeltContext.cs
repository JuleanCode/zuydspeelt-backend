using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Bogus;
using System;
using ZuydSpeelt.Models;

namespace ZuydSpeelt
{
    public class ZuydSpeeltContext : DbContext
    {
        // Making it possible to read the connectionstring from the appsettings.json file, in the future easier to change
        private readonly IConfiguration Configuration;
        public ZuydSpeeltContext(IConfiguration configuration)
        {
            Configuration = configuration;
            Fakedata.Init(100);
        }

        public DbSet<Category> Category { get; set; } = null!;
        public DbSet<Comment> Comment { get; set; } = null!;
        public DbSet<Game> Game { get; set; } = null!;
        public DbSet<Rating> Rating { get; set; } = null!;
        public DbSet<User> User { get; set; } = null!;
        public DbSet<UserGame> UserGame { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? envConnectionString = Environment.GetEnvironmentVariable("ZUYDSPEELT_CONNECTIONSTRING");

            if (envConnectionString != null)
            {
                optionsBuilder.UseNpgsql(envConnectionString);
            }
            else
            {
                optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(Fakedata.Users);
            modelBuilder.Entity<Category>().HasData(Fakedata.Categories);
            modelBuilder.Entity<Game>().HasData(Fakedata.Games);
            modelBuilder.Entity<UserGame>().HasData(Fakedata.UserGames);
            modelBuilder.Entity<Comment>().HasData(Fakedata.Comments);
            modelBuilder.Entity<Rating>().HasData(Fakedata.Ratings);
            modelBuilder.Entity<UserGame>().HasKey(e => new { e.UserId, e.GameId, e.CreatedAt });

            // Ignoring these to prevent double tables in this many to many relationship
            modelBuilder.Entity<User>().Ignore(e => e.Games);
            modelBuilder.Entity<Game>().Ignore(e => e.Users);

        }

        public static class Fakedata
        {
            public static List<User> Users = new List<User>();
            public static List<Category> Categories = new List<Category>();
            public static List<Game> Games = new List<Game>();
            public static List<UserGame> UserGames = new List<UserGame>();
            public static List<Comment> Comments = new List<Comment>();
            public static List<Rating> Ratings = new List<Rating>();
            public static int UserId { get; set; } = 1;
            public static int CategoryId { get; set; } = 1;
            public static int GameId { get; set; } = 1;
            public static int CommentId { get; set; } = 1;
            public static int RatingId { get; set; } = 1;



            public static void Init(int count)
            {
                var userFaker = new Faker<User>()
                    .RuleFor(u => u.Id, _ => UserId++)
                    .RuleFor(u => u.Username, f => f.Name.FirstName())
                    .RuleFor(u => u.Password, f => f.Hacker.Verb())
                    .RuleFor(u => u.Email, f => f.Internet.Email())
                    .RuleFor(u => u.CreatedAt, f => f.Date.Recent().ToUniversalTime());

                var categoryFaker = new Faker<Category>()
                    .RuleFor(c => c.Id, _ => CategoryId++)
                    .RuleFor(c => c.Name, f => f.Hacker.Verb());

                var gameFaker = new Faker<Game>()
                    .RuleFor(g => g.Id, _ => GameId++)
                    .RuleFor(g => g.CategoryId, f => f.Random.Number(1, Categories.Count))
                    .RuleFor(g => g.Title, f => f.Hacker.Phrase())
                    .RuleFor(g => g.CreatedAt, f => f.Date.Recent().ToUniversalTime())
                    .RuleFor(g => g.Popularity, f => f.Random.Number(1, 100));

                var userGameFaker = new Faker<UserGame>()
                    .RuleFor(u => u.UserId, f => f.Random.Number(1, Users.Count))
                    .RuleFor(u => u.GameId, f => f.Random.Number(1, Games.Count))
                    .RuleFor(u => u.CreatedAt, f => f.Date.Recent().ToUniversalTime())
                    .RuleFor(u => u.Score, f => f.Random.Number(1, 10));

                var commentFaker = new Faker<Comment>()
                    .RuleFor(c => c.Id, _ => CommentId++)
                    .RuleFor(c => c.UserId, f => f.Random.Number(1, Users.Count))
                    .RuleFor(c => c.GameId, f => f.Random.Number(1, Games.Count))
                    .RuleFor(c => c.Text, f => f.Hacker.Phrase())
                    .RuleFor(c => c.CreatedAt, f => f.Date.Recent().ToUniversalTime());

                var ratingFaker = new Faker<Rating>()
                    .RuleFor(r => r.Id, _ => RatingId++)
                    .RuleFor(r => r.UserId, f => f.Random.Number(1, Users.Count))
                    .RuleFor(r => r.GameId, f => f.Random.Number(1, Games.Count))
                    .RuleFor(r => r.Value, f => f.Random.Number(1, 5));

                var users = userFaker.Generate(count);
                Fakedata.Users.AddRange(users);
                var categories = categoryFaker.Generate(count);
                Fakedata.Categories.AddRange(categories);
                var games = gameFaker.Generate(count);
                Fakedata.Games.AddRange(games);
                var userGames = userGameFaker.Generate(count);
                Fakedata.UserGames.AddRange(userGames);
                var comments = commentFaker.Generate(count);
                Fakedata.Comments.AddRange(comments);
                var ratings = ratingFaker.Generate(count);
                Fakedata.Ratings.AddRange(ratings);
            }
        }
    }
}
