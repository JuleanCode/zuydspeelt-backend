﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZuydSpeelt.Models
{
    public class Comment
    {
        // Properties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, ForeignKey("User")]
        public int UserId { get; set; }
        [Required, ForeignKey("Game")]
        public int GameId { get; set; }
        [Required, DataType(DataType.Text)]
        public string Text { get; set; } = string.Empty;
        [Required, DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();

        // Relationships
        public User User { get; set; } = null!;
        public Game Game { get; set; } = null!;
    }
}