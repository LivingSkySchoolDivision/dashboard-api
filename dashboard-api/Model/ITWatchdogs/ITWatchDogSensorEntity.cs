using System;
using System.Collections.Generic;

namespace dashboard_api.Model.ITWatchDogs {

    public class ITWatchDogSensorEntity {
        public string name { get; set; }    
        public Dictionary<string, ITWatchDogSensorEntityMeasurement> measurement { get; set; }    
    }

}