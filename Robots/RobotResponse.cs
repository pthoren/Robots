using System;

namespace Robots
{
    public class RobotResponse
    {
        public int RobotId { get; set; }

        public double DistanceToGoal { get; set; }

        public double BatteryLevel { get; set; }
    }
}