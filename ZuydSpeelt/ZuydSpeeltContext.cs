using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        public DbSet<Category> Category { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserGame> UserGame { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("DefaultConnection"));
            string? customServer = Configuration["db_host"];
            string? customDb = Configuration["db_database"];
            string? customUser = Configuration["db_user"];
            string? customPassword = Configuration["db_password"];

            if (!string.IsNullOrEmpty(customServer) && !string.IsNullOrEmpty(customDb) && !string.IsNullOrEmpty(customUser) && !string.IsNullOrEmpty(customPassword))
            {
                connectionStringBuilder.DataSource = customServer;
                connectionStringBuilder.InitialCatalog = customDb;
                connectionStringBuilder.UserID = customUser;
                connectionStringBuilder.Password = customPassword;
                connectionStringBuilder.IntegratedSecurity = false; // disable Windows Authentication
            }
            optionsBuilder.UseSqlServer(connectionStringBuilder.ConnectionString);
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
