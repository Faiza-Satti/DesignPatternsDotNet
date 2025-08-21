using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Singelton.Model;

namespace Singelton.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IAppLogger _logger;

        public TestController(IAppLogger logger)
        {
            _logger = logger;
        }

        [HttpGet("check")]
        public IActionResult CheckSingleton()
        {           
            var logger1 = AppLogger.Instance;
            var logger2 = AppLogger.Instance;

            logger1.Log("Message 1");
            logger2.Log("Message 2");

            // Both are the same instance
            Console.WriteLine(ReferenceEquals(logger1, logger2));

            
            var instanceId = (_logger as AppLogger)?.InstanceId;
            _logger.Log("API endpoint hit");
            return Ok(new
            {
                Message = "Singleton check",
                InstanceId = instanceId
            });
        }
    }

}
