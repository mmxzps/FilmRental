using FilmRental.Models;
using FilmRental.Models.DTOs;

namespace FilmRental.Services.IServices
{
    public interface IAccountService
    {
        Task RegisterAccount(RegisterUserDTO registerUserDTO);

    }
}
