using System.ComponentModel.DataAnnotations.Schema;

namespace ZuydSpeelt.Models
{
    public class UserGame
    {
        // Properties
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Game")]
        public int GameId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int Score { get; set; }

        // Relationships
        public User User { get; set; } = null!;
        public Game Game { get; set; } = null!;
    }
}
