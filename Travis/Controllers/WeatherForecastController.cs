using Microsoft.AspNetCore.Mvc;

namespace Travis.Controllers
{
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet("")]
        public void Now(GeoCode geoCode)
        {
            return 
        }
    }
}
