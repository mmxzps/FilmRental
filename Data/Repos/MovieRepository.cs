using FilmRental.Data.Repos.IRepos;
using FilmRental.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FilmRental.Data.Repos
{
    public class MovieRepository : IMovieRepository
    {
        private readonly FilmRentalContext _filmRentalContext;
        public MovieRepository(FilmRentalContext filmRentalContext)
        {
            _filmRentalContext = filmRentalContext;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            var allMovies = await _filmRentalContext.Movies.ToListAsync();
            return allMovies;
        }

        public async Task<Movie> GetMovieByIdAsync(int movieId)
        {
            var theMovie = await _filmRentalContext.Movies.FindAsync(movieId);
            return theMovie;
        }

        public async Task AddMovieAsync(Movie movie)
        {
            _filmRentalContext.Movies.Add(movie);
            await _filmRentalContext.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            _filmRentalContext.Movies.Update(movie);
            await _filmRentalContext.SaveChangesAsync();
        }
        public async Task DeleteMovieAsync(int movieId)
        {
            var deletedMovie = await _filmRentalContext.Movies.FindAsync(movieId);
            _filmRentalContext.Movies.Remove(deletedMovie);
            await _filmRentalContext.SaveChangesAsync();
        }

    }
}
