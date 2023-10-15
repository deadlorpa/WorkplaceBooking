using Microsoft.AspNetCore.Mvc;
using WorkplaceBooking.Authorization;

namespace WorkplaceBooking.Controllers
{
    // TODO: complete controller RoomManagementController
    [ApiController]
    [Authorize]
    [Route("api/v1/RoomManagement")]
    public class RoomManagementController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public RoomManagementController(ILogger<UserController> logger)
        {
            _logger = logger;
        }
    }
}
