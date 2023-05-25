using System.ComponentModel.DataAnnotations;

namespace ZuydSpeelt
{
    public class User
    {
        // Properties
        [Key, Required]
        public int UserId { get; set; }
        [Required, DataType(DataType.Text)]
        public string? Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; } = DateTime.Now; // Default value when an object is made. So during registration, this is the current date and time.

        // Relationships
        public List<Comment> Comments { get; } = new();
        public List<Rating> Ratings { get; } = new();
        public List<Game> Games { get; } = new(); // Ignored in OnModelCreating to prevent double many to many tables
        public List<UserGame> UserGames { get; } = new();
    }
}
