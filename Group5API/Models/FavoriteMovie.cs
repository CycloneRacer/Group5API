using System.ComponentModel.DataAnnotations;

namespace Group5API.Models
{
    public class FavoriteMovie
    {
        [Key]
        public int Id { get; set; } // Primary Key (Column 1)

        [Required]
        public string Title { get; set; } = string.Empty; // Column 2

        public string Director { get; set; } = string.Empty; // Column 3

        public string Genre { get; set; } = string.Empty; // Column 4

        public int ReleaseYear { get; set; } // Column 5

        public double Rating { get; set; } // Column 6 (ex: 1.0 - 10.0)
    }
}