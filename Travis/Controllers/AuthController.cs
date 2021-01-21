using Microsoft.AspNetCore.Mvc;
using Travis.Models;

namespace Travis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(LoginRequestModel model)
        {
            return Ok("Quack Quack");
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequestModel model)
        {
            return Ok();
        }
    }
}
