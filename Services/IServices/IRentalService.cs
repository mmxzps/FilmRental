using FilmRental.Models;
using FilmRental.Models.DTOs;

namespace FilmRental.Services.IServices
{
    public interface IRentalService
    {
        Task<IEnumerable<RentalDTOShowInfo>> GetAllRentalsAsync();
        Task<RentalDTOShowInfo> GetRentalByIdAsync(int rentalId);
        Task AddRentalAsync(RentalEditDTO rental);
        Task UpdateRentalAsync(RentalEditDTO rental, int rentalId);
        Task DeleteRentalAsync(int rentalId);
    }
}
