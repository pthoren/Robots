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
        private readonly RobotService _robotService;

        public RobotsController(ILogger<RobotsController> logger)
        {
            _logger = logger;
            _robotService = new RobotService(new List<string> { "https://60c8ed887dafc90017ffbd56.mockapi.io/robots" });
        }

        [HttpPost]
        public async Task<RobotResponse> RequestRobot(RobotRequest request)
        {
            IEnumerable<Robot> robots = await _robotService.FetchRobots();
            Robot robot = robots.First();
            return new RobotResponse { RobotId = robot.RobotId, DistanceToGoal = 99, BatteryLevel = robot.BatteryLevel };
        }
    }
}
