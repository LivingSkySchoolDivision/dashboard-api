using System;
using System.Net.Http;
using System.Threading.Tasks;
using dashboard_api.Model.Weather;
using dashboard_api.Helpers.Weather;
using System.Collections.Generic;

namespace dashboard_api.Services {
    public class WeatherParserService {
        
        private readonly HttpClient _httpClient;
        private static readonly List<string> _validLocationPrefixes = new List<string>() { "ab", "bc", "mb", "nb", "nl", "nt", "ns", "nu", "on", "pe", "qc", "sk", "yt" };

        public WeatherParserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CurrentWeather> Get(string locationcode) {
            if (validateLocationCode(locationcode)) {

                CurrentWeather currentWeather = EnvCanadaCurrentWeatherParser.ParseXML(await _httpClient.GetStringAsync($"https://weather.gc.ca/rss/city/{locationcode}_e.xml"));

                // Hack because environment canada's weather station sk-34 doesn't seem to report temperature anymore. Use the closest one instead (sk-40).
                // Multiple other projects rely on this data, so changing this here is easier, though more hacky
                // Remove this if/when this ever gets fixed on Environment Canada's end.
                if (string.IsNullOrEmpty(currentWeather.TemperatureCelsius) && (locationcode == "sk-34")) 
                {                    
                    locationcode = "sk-40";
                    return EnvCanadaCurrentWeatherParser.ParseXML(await _httpClient.GetStringAsync($"https://weather.gc.ca/rss/city/sk-40_e.xml"));
                } else {
                    return currentWeather;
                }

            } else {
                return new CurrentWeather();
            }
        }

        private static bool validateLocationCode(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                if (input.Length > 3)
                {
                    if (_validLocationPrefixes.Contains(input.Substring(0, 2)))
                    {
                        if (input.Substring(2, 1) == "-")
                        {
                            string locationNumer = input.Substring(3, input.Length - 3);
                            int.TryParse(locationNumer, out int locationIDNumer);
                            if ((locationIDNumer > 0) && (locationIDNumer < 200))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

    }
}