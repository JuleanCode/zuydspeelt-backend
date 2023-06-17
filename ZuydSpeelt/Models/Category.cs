using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZuydSpeelt.Models
{
    public class Category
    {
        // Properties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, DataType(DataType.Text)]
        public string Name { get; set; } = null!;

        // Relationships
        public List<Game> Games { get; } = new();
    }
}