using System;
using System.Net.Http;
using System.Threading.Tasks;
using dashboard_api.Model.EnvironmentMonitors;
using dashboard_api.Model.ITWatchDogs;

namespace dashboard_api.Services {
    public class ITWatchDogService {
        
        private readonly HttpClient _httpClient;

        public ITWatchDogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ITWatchDogReading> GetReading(string uri) {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ITWatchDogReading>(await _httpClient.GetStringAsync(uri));
            //return new EnvironmentMonitorReading();
        }

    }
}