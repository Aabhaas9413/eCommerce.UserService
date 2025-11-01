using eCommerce.Core.Entities.DTOs;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerece.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            if(registerRequest is null)
            {
                return BadRequest("RegisterRequest cannot be null");
            }

            //Call the service method to register the user
            AuthenticationResponse? authResponse = await _userService.Register(registerRequest);
            if(authResponse is null || authResponse.Success == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "User registration failed");
            }
            return Ok(authResponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if(loginRequest is null)
            {
                return BadRequest("Username and password cannot be null or empty");
            }
            //Call the service method to login the user
            AuthenticationResponse? authResponse = await _userService.Login(loginRequest);
            if(authResponse is null || authResponse.Success == false)
            {
                return Unauthorized("Invalid username or password");
            }
            return Ok(authResponse);
        }
    }
}
