using Bogus;
using ZuydSpeelt.Models;

namespace ZuydSpeelt.Utils
{
    public static class DataSeeder
    {
        public static void Seed(ZuydSpeeltContext context)
        {
            Fakedata.Init(100);

            if (context.User.Any())  // check if data already exists, to prevent duplicate seeding
            {
                return;
            }

            // data seeding logic
            context.User.AddRange(Fakedata.Users);
            context.Category.AddRange(Fakedata.Categories);
            context.Game.AddRange(Fakedata.Games);
            context.UserGame.AddRange(Fakedata.UserGames);
            context.Comment.AddRange(Fakedata.Comments);
            context.Rating.AddRange(Fakedata.Ratings);

            context.SaveChanges();
        }
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
                .RuleFor(g => g.Title, f => f.Hacker.Verb())
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