using FilmRental.Data.Repos.IRepos;
using FilmRental.Models;
using FilmRental.Models.DTOs;
using FilmRental.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmRental.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieDtoShowInfo>> GetAllMoviesAsync()
        {
            var movieList = await _movieRepository.GetAllMoviesAsync();
            return movieList.Select(m => new MovieDtoShowInfo
            {
                Id = m.Id,
                Title = m.Title,
                ReleaseYear = m.ReleaseYear,
            }).ToList();
        }

        public async Task<MovieDTO> GetMovieByIdAsync(int movieId)
        {
            var theMovie = await _movieRepository.GetMovieByIdAsync(movieId);
            if(theMovie == null)
            {
                throw new ArgumentException($"Movie with ID {movieId} not found.");
            }
            var theMovieDto = new MovieDTO
            {
                Title = theMovie.Title,
                ReleaseYear = theMovie.ReleaseYear,
            };
            return theMovieDto;
        }

        public async Task AddMovieAsync(MovieDTO movieDto)
        {
            var addedMovie = new Movie
            {
                Title = movieDto.Title,
                ReleaseYear = movieDto.ReleaseYear,
            };
            await _movieRepository.AddMovieAsync(addedMovie);
        }

        public async Task UpdateMovieAsync(MovieDtoShowInfo movie)
        {
            var existingMovie = await _movieRepository.GetMovieByIdAsync(movie.Id);
            if (existingMovie == null)
            {
                throw new ArgumentException($"Movie with ID {movie.Id} not found.");
            }
            existingMovie.Title = movie.Title;
            existingMovie.ReleaseYear = movie.ReleaseYear;
            await _movieRepository.UpdateMovieAsync(existingMovie);
        }
        public async Task DeleteMovieAsync(int movieId)
        {
            var existingMovie = await _movieRepository.GetMovieByIdAsync(movieId);
            if (existingMovie == null)
            {
                throw new ArgumentException($"Movie with ID {movieId} not found.");
            }
            await _movieRepository.DeleteMovieAsync(existingMovie.Id);
            
        }

    }
}
