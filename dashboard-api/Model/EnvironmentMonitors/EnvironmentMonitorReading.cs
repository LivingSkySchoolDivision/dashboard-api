using System;
using System.Collections.Generic;

namespace dashboard_api.Model.EnvironmentMonitors {

    public class EnvironmentMonitorReading {
        public EnvironmentMonitorSystem System { get;set; }
        public EnvironmentMonitorTroubleshooting Troubleshooting { get;set; }
        public List<EnvironmentMonitorSensorReading> Sensors { get;set; }
    }
}