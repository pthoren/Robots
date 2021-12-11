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
        private readonly ILogger<RobotsController> log;
        private readonly RobotService robotService;

        public RobotsController(ILogger<RobotsController> logger)
        {
            this.log = log;
            this.robotService = new RobotService(new List<string> { "https://60c8ed887dafc90017ffbd56.mockapi.io/robots" });
        }

        [HttpPost]
        public async Task<LoadResponse> RequestRobot(LoadRequest request)
        {
            Robot robot = await robotService.SelectRobotForLoad(request);
            return new LoadResponse(robot.RobotId, 99, robot.BatteryLevel);
        }
    }
}
