using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZuydSpeelt
{
    public class Rating
    {
        // Properties
        [Key]
        public int RatingId { get; set; }
        [Required, ForeignKey("User")]
        public int UserId { get; set; }
        [Required, ForeignKey("Game")]
        public int GameId { get; set; }
        [Required]
        public int RatingValue { get; set; }

        // Relationships
        public User? User { get; set; }
        public Game? Game { get; set; }
    }
}