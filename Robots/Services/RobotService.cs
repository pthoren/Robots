using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Robots
{
    public class RobotService
    {
        private IEnumerable<string> apiUrls;
        private HttpClient client;

        public RobotService(IEnumerable<string> apiUrls)
        {
            this.apiUrls = apiUrls;
            this.client = new HttpClient();
        }

        public async Task<RobotWithDistance> SelectRobotForLoad(LoadRequest load)
        {
            IList<Robot> robots = await GetRobots();

            IEnumerable<RobotWithDistance> robotsOrderedByDistance = robots
                .Select(r => new RobotWithDistance(r.RobotId, r.BatteryLevel, r.X, r.Y, Utilities.Distance(r.X, r.Y, load.X, load.Y)))
                .OrderBy(r => r.Distance);

            IEnumerable<RobotWithDistance> robotsWithin10Units = robotsOrderedByDistance.Where(r => r.Distance < 10);

            return robotsWithin10Units.Any()
                ? robotsWithin10Units.OrderByDescending(r => r.BatteryLevel).First()
                : robotsOrderedByDistance.First();
        }

        public Task<IList<Robot>> GetRobots()
        {
            foreach (string url in apiUrls)
            {
                try
                {
                    return client.GetFromJsonAsync<IList<Robot>>(url);
                }
                catch (Exception e)
                {
                    // log
                }
            }

            throw new SystemException("failed to fetch robots");
        }
    }
}
