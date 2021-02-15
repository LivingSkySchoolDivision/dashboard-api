using System;
using System.Collections.Generic;

namespace dashboard_api.Model.ITWatchDogs {

    public class ITWatchDogSimplifiedReading {
        public string sensorid { get; set; }
        public string sensorname { get; set; }
        public decimal temperature { get; set; } = -999;
        public decimal humidity { get; set; } = -999;
        public string sensorlabel { get;set; }
        public string sensortype { get;set; }

        public ITWatchDogSimplifiedReading() {}
        public ITWatchDogSimplifiedReading(ITWatchDogReading reading, string sensorid) {

            // Convert a reading to a simplified reading
            foreach(string sid in reading.data.dev.Keys) {
                if (sid == sensorid) {
                    ITWatchDogSensor thisSensor = reading.data.dev[sid];

                    this.sensorid = sid;
                    this.sensorname = thisSensor.name;
                    this.sensorlabel = thisSensor.label;
                    this.sensortype = thisSensor.type;
                    
                    // Find measurements
                    foreach(ITWatchDogSensorEntity entity in thisSensor.entity.Values) {
                        foreach(ITWatchDogSensorEntityMeasurement measurement in entity.measurement.Values)
                        {
                            if (measurement.type == "temperature") {
                                decimal temp = -999;
                                if (decimal.TryParse(measurement.value, out temp)) {
                                    this.temperature = temp;
                                }
                            }
                            if (measurement.type == "humidity") {
                                decimal humi = -999;
                                if (decimal.TryParse(measurement.value, out humi)) {
                                    this.humidity = humi;
                                }
                                
                            }

                        }
                    }
                }
            }
        }
    }
}