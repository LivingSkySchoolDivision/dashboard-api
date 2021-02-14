using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dashboard_api.Model.Weather;
using dashboard_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dashboard_api.Controllers
{
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly WeatherParserService _service;

        public WeatherController(ILogger<WeatherController> logger, WeatherParserService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("[controller]/{locationcode}")]
        public async Task<CurrentWeather> Get(string locationcode)
        {            
            return await _service.Get(locationcode);
        }
        
    }
}
