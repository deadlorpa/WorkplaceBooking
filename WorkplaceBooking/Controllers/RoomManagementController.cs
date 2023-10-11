using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WorkplaceBooking.Controllers
{
    [ApiController]
    [Route("api/v1/RoomManagement")]
    public class RoomManagementController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public RoomManagementController(ILogger<UserController> logger)
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
