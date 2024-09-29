namespace FilmRental.Models.DTOs
{
    public class RentalEditDTO
    {
        public int FK_UserId { get; set; }
        public int FK_MovieId { get; set; }

        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
