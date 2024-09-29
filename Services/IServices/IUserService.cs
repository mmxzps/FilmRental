using FilmRental.Models;
using FilmRental.Models.DTOs;

namespace FilmRental.Services.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int userId);

        Task<int> AddUserAsync(UserDTO user);
        Task UpdateUserAsync(UserDTO user);

        Task DeleteUserAsync(int userId);
    }
}
