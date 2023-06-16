using System.ComponentModel.DataAnnotations;

namespace ZuydSpeelt.Models
{
    public class Category
    {
        // Properties
        [Key]
        public int Id { get; set; }
        [Required, DataType(DataType.Text)]
        public string Name { get; set; } = null!;

        // Relationships
        public List<Game> Games { get; } = new();
    }
}