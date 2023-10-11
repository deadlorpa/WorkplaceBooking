using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WorkplaceBooking.Controllers
{
    [ApiController]
    [Route("api/v1/Booking")]
    public class BookingController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public BookingController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Hi()
        {
            return Ok(new { message = "hi" });
        }
    }
}
