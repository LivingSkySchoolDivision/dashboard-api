using System;
using System.Net.Http;
using System.Threading.Tasks;
using dashboard_api.Model.EnvironmentMonitors;

namespace dashboard_api.Services {
    public class EnvironmentMonitorService {
        
        private readonly HttpClient _httpClient;

        public EnvironmentMonitorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EnvironmentMonitorReading> GetReading(string uri) {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<EnvironmentMonitorReading>(await _httpClient.GetStringAsync(uri));
            //return new EnvironmentMonitorReading();
        }

    }
}