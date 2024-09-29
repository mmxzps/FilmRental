using FilmRental.Data.Repos.IRepos;
using FilmRental.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmRental.Data.Repos
{
    public class AccountRepository : IAccountRepository
    {
        private readonly FilmRentalContext _filmRentalContext;

        public AccountRepository(FilmRentalContext filmRentalContext)
        {
            _filmRentalContext = filmRentalContext;
        }

        public async Task RegisterAccount(Account account)
        {
             _filmRentalContext.Accounts.Add(account);
           await _filmRentalContext.SaveChangesAsync();
        }


    }
}
