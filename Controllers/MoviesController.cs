using FilmRental.Models.DTOs;
using FilmRental.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        [HttpGet("ShowAllMovies")]
        public async Task<ActionResult<IEnumerable<MovieDtoShowInfo>>> ShowAllMovies()
        {
            var allUser = await _movieService.GetAllMoviesAsync();
            return Ok(allUser);
        }

        [HttpGet("GetMovieById/{id}")]
        public async Task<ActionResult<MovieDtoShowInfo>> GetMovieById(int id)
        {
            var theMovie = await _movieService.GetMovieByIdAsync(id);
            return Ok(theMovie);
        }

        [HttpPost("AddMovie")]
        public async Task<IActionResult> AddMovie(MovieDTO movieDTO)
        {
            await _movieService.AddMovieAsync(movieDTO);
            return Ok();
        }

        [HttpPut("UpdateMovie/{id}")]
        public async Task<IActionResult> UpdateMovie(int id, MovieDtoShowInfo dtomovie)
        {
            await _movieService.UpdateMovieAsync(dtomovie);
            return Ok();
        }

        [HttpDelete("DeletedMovie/{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _movieService.DeleteMovieAsync(id);
            return Ok();
        }
    }
}
