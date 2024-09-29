using FilmRental.Models;
using FilmRental.Models.DTOs;

namespace FilmRental.Services.IServices
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDtoShowInfo>> GetAllMoviesAsync();
        Task<MovieDTO> GetMovieByIdAsync(int movieId);
        Task AddMovieAsync(MovieDTO movie);
        Task UpdateMovieAsync(MovieDtoShowInfo movie);
        Task DeleteMovieAsync(int movieId);
    }
}
