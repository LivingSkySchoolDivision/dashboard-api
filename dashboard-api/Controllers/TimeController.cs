using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dashboard_api.Model.Time;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dashboard_api.Controllers
{
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly ILogger<TimeController> _logger;

        public TimeController(ILogger<TimeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/{timezone}")]
        public TimeResponse GetTimeZone(string timezone)
        {
            try {
                string parsedTimeZone = timezone.Replace('_','/');
                TimeZoneInfo specifiedTimeZone = TimeZoneInfo.FindSystemTimeZoneById(parsedTimeZone);
                DateTime adjustedTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, specifiedTimeZone);
                return new TimeResponse(adjustedTime);
            }
            catch { }

            return null;
        }

        [HttpGet]
        [Route("[controller]")]
        public TimeResponse Get()
        {
            return new TimeResponse(DateTime.UtcNow);
        }

    }
}
