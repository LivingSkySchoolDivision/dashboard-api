using System;
using System.Collections.Generic;

namespace dashboard_api.Model.EnvironmentMonitors {

    public class EnvironmentMonitorSystem {
        public string Hostname { get;set;}
        public decimal CPUTempCelsius { get;set; }
        public double UptimeSeconds { get; set; }
    }
}