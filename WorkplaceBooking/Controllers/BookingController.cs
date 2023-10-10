using Microsoft.AspNetCore.Mvc;

namespace WorkplaceBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public BookingController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Hi")]
        public async Task<IActionResult> Hi()
        {
            return Ok(new { message = "hi" });
        }
    }
}
