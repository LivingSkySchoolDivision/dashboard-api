using System;
using System.Collections.Generic;

namespace dashboard_api.Model.ITWatchDogs {

    public class ITWatchDogSensor {
        public string type { get;set; }
        public string state { get;set; }
        public string name { get; set; }
        public string label { get; set; }
        public Dictionary<string, ITWatchDogSensorEntity> entity { get;set; }
    }
}