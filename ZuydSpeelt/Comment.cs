using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZuydSpeelt
{
    public class Comment
    {
        // Properties
        [Key]
        public int CommentId { get; set; }
        [Required, ForeignKey("User")]
        public int UserId { get; set; }
        [Required, ForeignKey("Game")]
        public int GameId { get; set; }
        [Required, DataType(DataType.Text)]
        public string? CommentText { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime CommentDate { get; set; } = DateTime.Now;

        // Relationships
        public User? User { get; set; }
        public Game? Game { get; set; }
    }
}