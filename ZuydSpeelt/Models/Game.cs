using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ZuydSpeelt.Models
{
    public class Game
    {
        // Properties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, DataType(DataType.Text)]
        public string Title { get; set; } = null!;
        [Required, DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();
        [Required]
        public int Popularity { get; set; } = 0; // Starts default at 0
        [Required, ForeignKey("Category")]
        public int CategoryId { get; set; }

        // Relationships
        public Category Category { get; set; } = null!;
        public List<Rating> Ratings { get; } = new();
        public List<Comment> Comments { get; } = new();
        [JsonIgnore]
        public List<UserGame> UserGames { get; } = new();
    }
}