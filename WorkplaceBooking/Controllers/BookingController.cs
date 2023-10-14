using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkplaceBooking.Contracts.DataContracts;
using WorkplaceBooking.Contracts.Entities;
using WorkplaceBooking.Interfaces;
using WorkplaceBooking.Services;

namespace WorkplaceBooking.Controllers
{
    // TODO: complete controller
    [ApiController]
    [Route("api/v1/Booking")]
    public class BookingController : Controller
    {
        private IBookingService _bookingService;
        private readonly ILogger<UserController> _logger;

        public BookingController(IBookingService bookingService, ILogger<UserController> logger)
        {
            _bookingService = bookingService;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var records = await _bookingService.GetAll();
            return Ok(records);
        }

        [HttpGet("GetByUserId/{id}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var records = await _bookingService.GetByUserId(userId);
            return Ok(records);
        }

        [HttpGet("GetByWorkplaceId/{id}")]
        public async Task<IActionResult> GetByWorkplaceId(int workplaceId)
        {
            var records = await _bookingService.GetByWorkplaceId(workplaceId);
            return Ok(records);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var record = await _bookingService.GetById(id);
            return Ok(record);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(BookingRecordCreateDC request)
        {
            await _bookingService.Create(request);
            // TODO: or ret contract?
            return Ok(new { message = BookingRecordMessages.RecordCreated });
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, BookingRecordUpdateDC request)
        {
            await _bookingService.Update(id, request);
            // TODO: or ret contract?
            return Ok(new { message = BookingRecordMessages.RecordUpdated });
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookingService.Delete(id);
            // TODO: or ret contract?
            return Ok(new { message = BookingRecordMessages.RecordDeleted });
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Hi()
        {
            return Ok(new { message = "hi" });
        }
    }
}
