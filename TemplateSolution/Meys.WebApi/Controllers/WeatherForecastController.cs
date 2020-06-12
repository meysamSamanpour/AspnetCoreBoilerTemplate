using Microsoft.AspNetCore.Mvc;

namespace Meys.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Web API .... is Working";
        }
    }
}
