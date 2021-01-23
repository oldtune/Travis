using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordManager : ControllerBase
    {
        [HttpGet("")]
        public IActionResult List()
        {

        }
    }
}
