using System;
using System.Collections.Generic;

namespace dashboard_api.Model.ITWatchDogs {
    public class ITWatchDogData {
        public Dictionary<string, ITWatchDogSensor> dev { get;set; }
    }
}