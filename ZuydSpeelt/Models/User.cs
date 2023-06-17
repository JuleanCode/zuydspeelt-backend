using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ZuydSpeelt.Models
{
    public class User
    {
        // Properties
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, DataType(DataType.Text)]
        public string Username { get; set; } = null!;
        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Required, DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime(); // Default value when an object is made. So during registration, this is the current date and time.

        // Relationships
        public List<Comment> Comments { get; } = new();
        public List<Rating> Ratings { get; } = new();
        [JsonIgnore]
        public List<UserGame> UserGames { get; } = new();
    }
}
