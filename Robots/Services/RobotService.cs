using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Robots
{
    public class RobotService
    {
        private IEnumerable<string> _apiUrls;
        private HttpClient _client;

        public RobotService(IEnumerable<string> apiUrls)
        {
            _apiUrls = apiUrls;
            _client = new HttpClient();
        }

        public Task<IEnumerable<Robot>> FetchRobots()
        {
            foreach (string url in _apiUrls)
            {
                try
                {
                    return _client.GetFromJsonAsync<IEnumerable<Robot>>(url);
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
