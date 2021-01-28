using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : ControllerBase
    {
        /// <summary>
        /// Get with code to secure your system
        /// </summary>
        /// <param name="code"></param>
        [HttpGet("")]
        public void FetchAll(string code, string query)
        {
            //expression trees to the rescue to query all string field (propably all fields in this aggregate are string)
            var getPasswordRequest = new PasswordRequest();
        }
    }
}
