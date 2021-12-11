using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Robots.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotsController : ControllerBase
    {
        private readonly ILogger<RobotsController> _logger;

        public RobotsController(ILogger<RobotsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public RobotResponse RequestRobot(RobotRequest request)
        {
            return new RobotResponse { RobotId = request.LoadId, DistanceToGoal = request.X, BatteryLevel = request.Y };
        }
    }
}
