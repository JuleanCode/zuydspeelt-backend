using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ZuydSpeelt
{
    public class ZuydSpeeltContext : DbContext
    {
        // Making it possible to read the connectionstring from the appsettings.json file, in the future easier to change
        private readonly IConfiguration Configuration ;
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
            modelBuilder.Entity<UserGame>().HasKey(e => new { e.UserId, e.GameId, e.PlayDate });

            // Ignoring these to prevent double tables in this many to many relationship
            modelBuilder.Entity<User>().Ignore(e => e.Games);
            modelBuilder.Entity<Game>().Ignore(e => e.Users);
        }
    }
}
