using FilmRental.Data.Repos.IRepos;
using FilmRental.Models;
using FilmRental.Models.DTOs;
using FilmRental.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FilmRental.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<IEnumerable<RentalDTOShowInfo>> GetAllRentalsAsync()
        {
            var allRentals = await _rentalRepository.GetAllRentalsAsync();

            if (allRentals == null)
            {
                return null;
            }

            return allRentals.Select(r => new RentalDTOShowInfo
            {
                Id = r.Id,
                FK_UserId = r.FK_UserId,
                FK_MovieId = r.FK_MovieId,
                LoanDate = r.LoanDate,
                ReturnDate = r.ReturnDate,
            }).ToList();
        }

        public async Task<RentalDTOShowInfo> GetRentalByIdAsync(int rentalId)
        {
            var rental = await _rentalRepository.GetRentalByIdAsync(rentalId);

            if(rental == null)
            {
                return null;
            }
            return new RentalDTOShowInfo
            {
                Id = rental.Id,
                FK_MovieId = rental.FK_MovieId,
                FK_UserId = rental.FK_UserId,
                LoanDate = rental.LoanDate,
                ReturnDate = rental.ReturnDate,
            };
        }

        public async Task AddRentalAsync(RentalEditDTO rental)
        {
            await _rentalRepository.AddRentalAsync(new Rental
            {
                FK_MovieId = rental.FK_MovieId,
                FK_UserId = rental.FK_UserId,
                LoanDate = rental.LoanDate,
                ReturnDate = rental.ReturnDate,
            });
        }

        public async Task UpdateRentalAsync(RentalEditDTO rental, int rentalId)
        {
            var existedRental = await _rentalRepository.GetRentalByIdAsync(rentalId);

            existedRental.FK_UserId = rental.FK_UserId;
            existedRental.FK_MovieId = rental.FK_MovieId;
            existedRental.LoanDate = rental.LoanDate;
            existedRental.ReturnDate = rental.ReturnDate;

            await _rentalRepository.UpdateRentalAsync(existedRental);
        }
        public async Task DeleteRentalAsync(int rentalId)
        {
            await _rentalRepository.DeleteRentalAsync(rentalId);
        }

    }
}
