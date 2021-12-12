using System;

namespace Robots
{
    public record LoadResponse(string RobotId, double DistanceToGoal, double BatteryLife);
}
