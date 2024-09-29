using FilmRental.Data.Repos.IRepos;
using FilmRental.Models;
using FilmRental.Models.DTOs;
using FilmRental.Services.IServices;

namespace FilmRental.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            throw new NotImplementedException();
        }

        public Task RegisterAccount(RegisterUserDTO registerUserDTO)
        {
            throw new NotImplementedException();
        }
    }
}
