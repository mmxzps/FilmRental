using System.ComponentModel.DataAnnotations;

namespace FilmRental.Models.DTOs
{
    public class MovieDtoShowInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
    }
}
