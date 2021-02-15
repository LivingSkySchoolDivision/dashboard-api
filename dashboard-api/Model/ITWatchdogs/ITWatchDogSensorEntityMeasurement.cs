using System;
using System.Collections.Generic;

namespace dashboard_api.Model.ITWatchDogs {

    public class ITWatchDogSensorEntityMeasurement {
        public string type { get; set; }
        public string value { get; set; }
        public string state { get; set; }
        public string units { get; set; }        
    }

    

}