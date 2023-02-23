
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/command/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        {
            
        }

        public ActionResult TestBoundConnection()
        {
            System.Console.WriteLine("--> Inbound POST # Command Service");
            return Ok("Inbound test from Platforms Controller");
        }
    }
}