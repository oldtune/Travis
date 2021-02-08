using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travis.Controllers
{
    /// <summary>
    /// Well, use randomized code issued by another provider (another api, but my as well)
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SitePasswordController : ControllerBase
    {
        /// <summary>
        /// Get with code to secure your system
        /// </summary>
        /// <param name="code"></param>
        [HttpGet("")]
        public IActionResult FetchAll(string code, string query)
        {
            //expression trees to the rescue to query all string field (propably all fields in this aggregate are string)
            return Ok();
        }

        [HttpPost("")]
        public IActionResult Add()
        {
            return Ok();
        }

        [HttpPut("")]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpDelete("")]
        public IActionResult Remove()
        {
            return Ok();
        }
    }
}
