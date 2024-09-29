using System.ComponentModel.DataAnnotations;

namespace FilmRental.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        [MinLength(3)]
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public ICollection<Rental> Rentals { get; set; }
    }
}
