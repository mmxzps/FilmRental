using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FilmRental.Models.DTOs
{
    public class RentalDTOShowInfo
    {
        public int Id { get; set; }

        public int FK_UserId { get; set; }
        public int FK_MovieId { get; set; }

        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
