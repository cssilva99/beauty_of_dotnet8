using Microsoft.AspNetCore.Mvc;
using Stratio.Challenges.VehicleMaintenances.Api.Services;

namespace Stratio.Challenges.VehicleMaintenances.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            // Calling the Database Mock Service
            var token = await _authService.Login(model.Email, model.Password);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized(new { message = "Credenciais inválidas ou utilizador não encontrado." });
            }

            // Return the token in a JSON formatt (we will be using Thunder Client for tests)
            return Ok(new { token });
        }
    }

    // This is a helper class to support the request body
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
