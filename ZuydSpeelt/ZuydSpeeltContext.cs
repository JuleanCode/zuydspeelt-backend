using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Bogus;
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
            Fakedata.Init(10);

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

            public static void Init(int count)
            {
                var UserId = 1;
                var userFaker = new Faker<User>()
                    .RuleFor(u => u.Id, _ => UserId++)
                    .RuleFor(u => u.Username, f => f.Name.FirstName())
                    .RuleFor(u => u.Password, f => f.Hacker.Verb())
                    .RuleFor(u => u.Email, f => f.Internet.Email())
                    .RuleFor(u => u.CreatedAt, f => f.Date.Recent());

                var CategoryId = 1;
                var categoryFaker = new Faker<Category>()
                    .RuleFor(c => c.Id, _ => CategoryId++)
                    .RuleFor(c => c.Name, f => f.Hacker.Verb());

                var GameId = 1;
                var gameFaker = new Faker<Game>()
                    .RuleFor(g => g.Id, _ => GameId++)
                    .RuleFor(g => g.Title, f => f.Hacker.Phrase())
                    .RuleFor(g => g.CreatedAt, f => f.Date.Recent())
                    .RuleFor(g => g.Popularity, f => f.Random.Number(1, 5));

                var userGameFaker = new Faker<UserGame>()
                    .RuleFor(u => u.UserId, f => f.Random.Number(1, Users.Count))
                    .RuleFor(u => u.GameId, f => f.Random.Number(1, Games.Count))
                    .RuleFor(u => u.CreatedAt, f => f.Date.Recent())
                    .RuleFor(u => u.Score, f => f.Random.Number(1, 10));

                var CommentId = 1;
                var commentFaker = new Faker<Comment>()
                    .RuleFor(c => c.Id, _ => CommentId++)
                    .RuleFor(c => c.UserId, f => f.Random.Number(1, Users.Count))
                    .RuleFor(c => c.GameId, f => f.Random.Number(1, Games.Count))
                    .RuleFor(c => c.Text, f => f.Hacker.Phrase())
                    .RuleFor(c => c.CreatedAt, f => f.Date.Recent());

                var ratingId = 1;
                var ratingFaker = new Faker<Rating>()
                    .RuleFor(r => r.Id, _ => ratingId++)
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
