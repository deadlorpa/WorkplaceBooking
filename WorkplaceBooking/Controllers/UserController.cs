using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorkplaceBooking.Contracts.DataContracts;
using WorkplaceBooking.Contracts.Entities;
using WorkplaceBooking.Interfaces;

namespace WorkplaceBooking.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        #region Auth

        [HttpPost("Auth")]
        public async Task<IActionResult> Auth(UserAuthRequestDC request)
        {
            var responce = await _userService.Auth(request);
            return Ok(responce);
        }

        #endregion

        #region CRUD

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }

        [HttpGet("GetByEmail/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _userService.GetByEmail(email);
            return Ok(user);
        }

        // TODO: рассмотреть создание специального атрибута админа?
        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(UserCreateRequestDC request)
        {
            await _userService.Create(request);
            // TODO: или возвращать контракт?
            return Ok(new { message = UserMessages.UserCreated});
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, UserUpdateRequestDC request)
        {
            await _userService.Update(id, request);
            // TODO: или возвращать контракт?
            return Ok(new { message = UserMessages.UserUpdated });
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            // TODO: или возвращать контракт?
            return Ok(new { message = UserMessages.UserDeleted });
        }

        #endregion

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Hi()
        {
            return Ok(new { message = "hi" });
        }
    }
}