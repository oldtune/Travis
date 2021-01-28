using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        public NewsController()
        {

        }

        [HttpGet("")]
        public IActionResult Fetch()
        {
            return Ok();
        }

        [HttpGet("force-get")]
        public IActionResult ForceFetch()
        {
            return Ok();
        }
    }
}
