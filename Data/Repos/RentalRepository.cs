using FilmRental.Data.Repos.IRepos;
using FilmRental.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FilmRental.Data.Repos
{
    public class RentalRepository : IRentalRepository
    {
        private readonly FilmRentalContext _filmRentalContext;
        public RentalRepository(FilmRentalContext filmRentalContext)
        {
            _filmRentalContext = filmRentalContext;
        }

        public async Task<IEnumerable<Rental>> GetAllRentalsAsync()
        {
            var allRentals = await _filmRentalContext.Rentals.ToListAsync();
            return allRentals;
        }

        public async Task<Rental> GetRentalByIdAsync(int rentalId)
        {
            var theRental = await _filmRentalContext.Rentals.FirstOrDefaultAsync(x=> x.Id == rentalId);
            return theRental;
        }

        public async Task AddRentalAsync(Rental rental)
        {
             _filmRentalContext.Add(rental);
            await _filmRentalContext.SaveChangesAsync();
        }

        public async Task UpdateRentalAsync(Rental rental)
        {
            _filmRentalContext.Rentals.Update(rental);
            await _filmRentalContext.SaveChangesAsync();
        }
        public async Task DeleteRentalAsync(int rentalId)
        {
            var deleteRental = await _filmRentalContext.Rentals.FindAsync(rentalId);
            _filmRentalContext.Rentals.Remove(deleteRental);
            await _filmRentalContext.SaveChangesAsync();
        }

    }
}
