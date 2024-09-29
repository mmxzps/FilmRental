using FilmRental.Models;

namespace FilmRental.Data.Repos.IRepos
{
    public interface IAccountRepository
    {
        Task RegisterAccount(Account account);

    }
}
