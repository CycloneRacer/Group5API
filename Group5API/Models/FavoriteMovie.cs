using System.ComponentModel.DataAnnotations;

namespace Group5API.Models
{
    public class FavoriteMovie
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Director { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;

        public int ReleaseYear { get; set; }

        public double Rating { get; set; } //(movie rating 1.0 - 10.0)
    }
}