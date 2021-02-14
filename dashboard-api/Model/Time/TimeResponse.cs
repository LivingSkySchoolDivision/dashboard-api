using System;

namespace dashboard_api.Model.Time {

    public class TimeResponse {        
        
        private readonly DateTime timereference;

        public int Year => timereference.Year;
        public int Month => timereference.Month;
        public int Day => timereference.Day;
        public int Hour => timereference.Hour;
        public int Minute => timereference.Minute;
        public int Second => timereference.Second;
        public int Millisecond => timereference.Millisecond;

        public TimeResponse(DateTime TimeReference) {
            this.timereference = TimeReference;
        }


    }
}