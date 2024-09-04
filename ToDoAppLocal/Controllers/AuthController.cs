using Microsoft.AspNetCore.Mvc;
using ToDoAppLocal.Models;
using ToDoAppLocal.Services;

namespace ToDoAppLocal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _jwtTokenService;

        public AuthController(JwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("login")]
        public ActionResult<AuthenticateResponse> Login(AuthenticateRequest request)
        {
            // Here you would validate the user's credentials (e.g., check username and password)
            // For simplicity, let's assume the credentials are valid

            var token = _jwtTokenService.GenerateToken(request.Username);
            var response = new AuthenticateResponse(request.Username, token);

            return Ok(response);
        }
    }
}
