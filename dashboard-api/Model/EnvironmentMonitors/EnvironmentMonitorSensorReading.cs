using System;
using System.Collections.Generic;

namespace dashboard_api.Model.EnvironmentMonitors {

    public class EnvironmentMonitorSensorReading {
        public string Name { get; set; }
        public decimal TemperatureCelsius { get; set; }
        public decimal Humidity { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsError { get; set; }
    }

}