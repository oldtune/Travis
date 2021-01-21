using Microsoft.AspNetCore.Mvc;

namespace Travis.Controllers
{
    [ApiController]
    public class AirController : ControllerBase
    {
        [HttpGet("")]
        public void Now(GeoCode geoCode)
        {
            return null;
        }
    }
}
