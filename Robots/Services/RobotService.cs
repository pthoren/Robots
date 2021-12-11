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

        public async Task<Robot> SelectRobotForLoad(LoadRequest load)
        {
            IEnumerable<Robot> robots = await GetRobots();
            return robots.First();
        }

        public Task<IEnumerable<Robot>> GetRobots()
        {
            foreach (string url in apiUrls)
            {
                try
                {
                    return client.GetFromJsonAsync<IEnumerable<Robot>>(url);
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
