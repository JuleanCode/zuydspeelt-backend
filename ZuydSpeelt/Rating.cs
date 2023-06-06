using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZuydSpeelt
{
    public class Rating
    {
        // Properties
        [Key]
        public int Id { get; set; }
        [Required, ForeignKey("User")]
        public int UserId { get; set; }
        [Required, ForeignKey("Game")]
        public int GameId { get; set; }
        [Required]
        public int Value { get; set; }

        // Relationships
        public User User { get; set; } = null!;
        public Game Game { get; set; } = null!;
    }
}