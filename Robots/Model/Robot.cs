using System;

namespace Robots
{
    public record Robot(string RobotId, double BatteryLevel, int X, int Y);
    public record RobotWithDistance(string RobotId, double BatteryLevel, int X, int Y, double Distance);
}
