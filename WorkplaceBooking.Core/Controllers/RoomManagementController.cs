using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using WorkplaceBooking.Core.Authorization;
using WorkplaceBooking.Core.Contracts.DataContracts;
using WorkplaceBooking.Core.Interfaces;

namespace WorkplaceBooking.Core.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/RoomManagement")]
    public class RoomManagementController : Controller
    {
        private IRoomManagementService _roomManagementService;
        private readonly ILogger<UserController> _logger;
        private readonly IStringLocalizer<RoomManagementController> _localizer;

        public RoomManagementController(IRoomManagementService roomManagementService,
            ILogger<UserController> logger,
            IStringLocalizer<RoomManagementController> localizer)
        {
            _roomManagementService = roomManagementService;
            _logger = logger;
            _localizer = localizer;
        }

        [HttpPost("CreateRoom")]
        public async Task<IActionResult> CreateRoom(RoomCreateRequestDC request)
        {
            var room = await _roomManagementService.CreateRoom(request);
            return Ok(room);
        }

        [HttpPost("CreateWorkplace")]
        public async Task<IActionResult> CreateWorkplace(WorkplaceCreateRequestDC request)
        {
            var workplace = await _roomManagementService.CreateWorkplace(request);
            return Ok(workplace);
        }

        [HttpGet("GetWorkplacesByRoomID/{roomId}")]
        public async Task<IActionResult> GetWorkplacesByRoomId(int roomId)
        {
            var workplaces = await _roomManagementService.GetWorkplacesByRoomId(roomId);
            return Ok(workplaces);
        }

        [HttpGet("GetFull")]
        public async Task<IActionResult> GetFull()
        {
            var rooms = await _roomManagementService.GetFull();
            return Ok(rooms);
        }

        [HttpGet("GetAllRooms")]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _roomManagementService.GetAllRooms();
            return Ok(rooms);
        }

        [HttpDelete("DeleteRoom/{roomId}")]
        public async Task<IActionResult> DeleteRoom(int roomId)
        {
            await _roomManagementService.DeleteRoom(roomId);
            return Ok(new { message = _localizer["RoomDeleted"].Value });
        }

        [HttpDelete("DeleteWorkplace/{workplaceId}")]
        public async Task<IActionResult> DeleteWorkplace(int workplaceId)
        {
            await _roomManagementService.DeleteWorkplace(workplaceId);
            return Ok(new { message = _localizer["WorplaceDeleted"].Value });
        }

        [HttpPut("UpdateRoom/{roomId}")]
        public async Task<IActionResult> UpdateWorkplace(int roomId, RoomUpdateRequestDC request)
        {
            await _roomManagementService.UpdateRoom(roomId, request);
            return Ok(new { message = _localizer["RoomUpdated"].Value });
        }

        [HttpPut("UpdateWorkplace/{workplaceId}")]
        public async Task<IActionResult> UpdateWorkplace(int workplaceId, WorkplaceUpdateRequestDC request)
        {
            await _roomManagementService.UpdateWorkplace(workplaceId, request);
            return Ok(new { message = _localizer["WorplaceUpdated"].Value });
        }
    }
}
