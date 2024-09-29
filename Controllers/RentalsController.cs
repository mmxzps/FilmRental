using FilmRental.Models.DTOs;
using FilmRental.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("ShowAllRentals")]
        public async Task<IEnumerable<RentalDTOShowInfo>> ShowAllRentals()
        {
            return await _rentalService.GetAllRentalsAsync();
        }

        [HttpGet("GetRentalById/{rentalId}")]
        public async Task<ActionResult<RentalDTOShowInfo>> GetRentalById(int rentalId)
        {
            var theRental = await _rentalService.GetRentalByIdAsync(rentalId);
            if (theRental == null)
            {
                return NotFound();
            }
            return Ok(theRental);
        }

        [HttpPost("AddRental")]
        public async Task<IActionResult> AddRental(RentalEditDTO rentalEditDTO)
        {
            await _rentalService.AddRentalAsync(rentalEditDTO);
            return Created();
        }

        [HttpPut("UpdateRental/{rentalId}")]
        public async Task<IActionResult> UpdateRental(RentalEditDTO rentalEditDTO, int rentalId)
        {
            await _rentalService.UpdateRentalAsync(rentalEditDTO, rentalId);
            return Ok();
        }

        [HttpDelete("DeleteRental/{rentalId}")]
        public async Task<IActionResult> DeletedRental(int rentalId)
        {
            await _rentalService.DeleteRentalAsync(rentalId);
            return Ok();
        }
    }
}
