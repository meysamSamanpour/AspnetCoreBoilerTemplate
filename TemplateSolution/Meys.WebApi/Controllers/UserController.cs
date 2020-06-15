using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meys.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        [HttpGet, Route("Get")]
        public string Get()
        {
            return "User Controller is working";
        }
    }
}
