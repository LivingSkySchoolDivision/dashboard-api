using System;
using System.Collections.Generic;

namespace dashboard_api.Model.EnvironmentMonitors {

    public class EnvironmentMonitorTroubleshooting {
        public DateTime LastScan { get;set; }
        public string Errormessage { get;set; }
    }
}