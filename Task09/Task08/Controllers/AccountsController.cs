using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Task08.Models.DTO;
using Task08.Services;
using Task08.Helpers;

namespace Task08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private IAccountsDbService service;

        public AccountsController(IAccountsDbService service)
        {
            this.service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto dto)
        {
            var result = await service.RegisterAsync(dto);

            switch (result)
            {
                case DbAnswer.OK:
                    return Ok("registered");
                case DbAnswer.PasswordLengthIsNotProper:
                    return BadRequest("password should be at least 6 characters");
                case DbAnswer.UserIsAlreadyRegistered:
                    return BadRequest("login is taken");
                default:
                    return StatusCode(500);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto dto)
        {
            var result = await service.LoginAsync(dto);

            switch (result.DbAnswer)
            {
                case DbAnswer.OK:
                    return Ok(result);
                case DbAnswer.BadPassword:
                    return Unauthorized("wrong password");
                case DbAnswer.UserNotFound:
                    return Unauthorized("login not found");
                default:
                    return Unauthorized();
            }
        }

        [HttpPost("updateAccessToken")]
        public async Task<IActionResult> UpdateAccessToken(RefreshTokenDto dto)
        {
            var result = await service.UpdateAccessTokenAsync(dto);

            switch (result.DbAnswer)
            {
                case DbAnswer.OK:
                    return Ok(result);
                case DbAnswer.RefreshTokenIsExpired:
                    return BadRequest("refresh token expired");
                case DbAnswer.UserNotFound:
                    return BadRequest("user not found");
                default:
                    return Unauthorized();
            }
        }
    }

}
