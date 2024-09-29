using FilmRental.Models;
using FilmRental.Models.DTOs;

namespace FilmRental.Data.Repos.IRepos
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);

        Task<int> AddUserAsync(User user);
        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(int userId);
    }
}
