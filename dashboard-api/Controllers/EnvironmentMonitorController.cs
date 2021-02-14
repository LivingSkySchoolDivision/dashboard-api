using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dashboard_api.Model.EnvironmentMonitors;
using dashboard_api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dashboard_api.Controllers
{
    [ApiController]
    public class EnvironmentMonitorController : ControllerBase
    {
        private readonly ILogger<EnvironmentMonitorController> _logger;
        private readonly EnvironmentMonitorService _service;

        public EnvironmentMonitorController(ILogger<EnvironmentMonitorController> logger, EnvironmentMonitorService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("[controller]/{sensorip}")]
        public async Task<EnvironmentMonitorReading> Get(string sensorip)
        {            
            return await _service.GetReading($"http://{sensorip}/");
        }

        [HttpGet]
        [Route("[controller]/{sensorip}/system")]
        public async Task<EnvironmentMonitorSystem> GetSystem(string sensorip)
        {            
            EnvironmentMonitorReading reading = await _service.GetReading($"http://{sensorip}/");;
            return reading.System;
        }

        
        [HttpGet]
        [Route("[controller]/{sensorip}/{sensorname}")]
        public async Task<EnvironmentMonitorSensorReading> GetSensor(string sensorip, string sensorname)
        {            
            EnvironmentMonitorReading reading = await _service.GetReading($"http://{sensorip}/");;
            
            foreach(EnvironmentMonitorSensorReading sensor in reading.Sensors) {
                if (sensor.Name.Equals(sensorname, StringComparison.InvariantCultureIgnoreCase)) {
                    return sensor;
                }
            }

            return new EnvironmentMonitorSensorReading();
        }
        
    }
}
