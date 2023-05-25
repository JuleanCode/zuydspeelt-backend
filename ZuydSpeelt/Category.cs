using System.ComponentModel.DataAnnotations;

namespace ZuydSpeelt
{
    public class Category
    {
        // Properties
        [Key]
        public int CategoryId { get; set; }
        [Required, DataType(DataType.Text)]
        public string? CategoryName { get; set; }

        // Relationships
        public List<Game> Games { get; } = new();
    }
}