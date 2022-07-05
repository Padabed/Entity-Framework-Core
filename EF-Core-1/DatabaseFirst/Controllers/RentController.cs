using Microsoft.AspNetCore.Mvc;
using DatabaseFirst.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DatabaseFirst.Controllers
{
    [Route("api/cars")]
    public class RentController : Controller
    {
        public IRentalService _rentalService { get; set; }
        public RentController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetRentalsAsync(int Id)
        {
            try
            {
                var rentals = await _rentalService.GetRentals(Id);
                return Ok(rentals);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}

