using System.ComponentModel.DataAnnotations.Schema;

namespace ZuydSpeelt
{
    public class UserGame
    {
        // Properties
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Game")]
        public int GameId { get; set; }
        public DateTime PlayDate { get; set; } = DateTime.Now;
        public int Score { get; set; }

        // Relationships
        public User User { get; set; }
        public Game Game { get; set; }
    }
}
