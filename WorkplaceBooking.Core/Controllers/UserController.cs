using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using WorkplaceBooking.Core.Authorization;
using WorkplaceBooking.Core.Contracts.DataContracts;
using WorkplaceBooking.Core.Interfaces;

namespace WorkplaceBooking.Core.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly IStringLocalizer<UserController> _localizer;

        public UserController(IUserService userService,
            ILogger<UserController> logger,
            IStringLocalizer<UserController> localizer)
        {
            _userService = userService;
            _logger = logger;
            _localizer = localizer;
        }

        #region Auth

        [AllowAnonymous]
        [HttpPost("Auth")]
        public async Task<IActionResult> Auth(UserAuthRequestDC request)
        {
            var responce = await _userService.Auth(request);
            return Ok(responce);
        }

        #endregion

        #region CRUD

        [Admin]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [Admin]
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }

        [Admin]
        [HttpGet("GetByEmail/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _userService.GetByEmail(email);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(UserCreateRequestDC request)
        {
            await _userService.Create(request);
            return Ok(new { message = _localizer["Created"].Value });
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, UserUpdateRequestDC request)
        {
            await _userService.Update(id, request);
            return Ok(new { message = _localizer["Updated"].Value });
        }

        [Admin]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok(new { message = _localizer["Deleted"].Value });
        }

        #endregion
    }
}