using Microsoft.AspNetCore.Mvc;
using WorkplaceBooking.Authorization;
using WorkplaceBooking.Contracts.DataContracts;
using WorkplaceBooking.Contracts.Entities;
using WorkplaceBooking.Interfaces;

namespace WorkplaceBooking.Controllers
{
    // TODO: remove anon after tests
    [ApiController]
    [Authorize]
    [Route("api/v1/RoomManagement")]
    public class RoomManagementController : Controller
    {
        private IRoomManagementService _roomManagementService;
        private readonly ILogger<UserController> _logger;

        public RoomManagementController(IRoomManagementService roomManagementService,ILogger<UserController> logger)
        {
            _roomManagementService = roomManagementService;
            _logger = logger;
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
            return Ok(new {RoomMessages.RoomDeleted});
        }

        [HttpDelete("DeleteWorkplace/{workplaceId}")]
        public async Task<IActionResult> DeleteWorkplace(int workplaceId)
        {
            await _roomManagementService.DeleteWorkplace(workplaceId);
            return Ok(new { WorkplaceMessages.WorplaceDeleted });
        }

        [HttpPut("UpdateRoom/{roomId}")]
        public async Task<IActionResult> UpdateWorkplace(int roomId, RoomUpdateRequestDC request)
        {
            await _roomManagementService.UpdateRoom(roomId, request);
            return Ok(new { RoomMessages.RoomUpdated });
        }

        [HttpPut("UpdateWorkplace/{workplaceId}")]
        public async Task<IActionResult> UpdateWorkplace(int workplaceId, WorkplaceUpdateRequestDC request)
        {
            await _roomManagementService.UpdateWorkplace(workplaceId, request);
            return Ok(new { WorkplaceMessages.WorplaceUpdated });
        }
    }
}
