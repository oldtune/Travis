using Microsoft.AspNetCore.Mvc;
using System;

namespace Travis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnvironmentController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(new
            {
                Environment.Is64BitOperatingSystem,
                Environment.Is64BitProcess,
                Environment.OSVersion,
                Environment.ProcessId,
                Environment.ProcessorCount,
                Environment.UserName,
                Environment.CurrentManagedThreadId
            });
        }
    }
}
