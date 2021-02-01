using Microsoft.AspNetCore.Mvc;

namespace Travis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirController : ControllerBase
    {
        [HttpGet("")]
        public void Now(GeoCode geoCode)
        {
        }
    }
}
