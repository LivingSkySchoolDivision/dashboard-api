using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dashboard_api.Model.EnvironmentMonitors;
using dashboard_api.Model.ITWatchDogs;
using dashboard_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dashboard_api.Controllers
{
    [ApiController]
    public class ITWatchDogController : ControllerBase
    {
        private readonly ILogger<EnvironmentMonitorController> _logger;
        private readonly ITWatchDogService _service;

        public ITWatchDogController(ILogger<EnvironmentMonitorController> logger, ITWatchDogService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("[controller]/{sensorip}")]
        public async Task<ITWatchDogReading> Get(string sensorip)
        {            
            return await _service.GetReading($"http://{sensorip}/api");
        }

        [HttpGet]
        [Route("[controller]/{sensorip}/{sensorid}")]
        public async Task<ITWatchDogSimplifiedReading> Get(string sensorip, string sensorid)
        {   
            ITWatchDogReading reading = await _service.GetReading($"http://{sensorip}/api");
            return new ITWatchDogSimplifiedReading(reading, sensorid);
        }
        
    }
}
