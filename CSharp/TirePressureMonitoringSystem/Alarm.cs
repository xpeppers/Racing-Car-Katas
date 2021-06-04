namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        ISensor _sensor;

        bool _alarmOn = false;
        private long _alarmCount = 0;

        public Alarm()
        {
            this._sensor = new Sensor();
        }

        public Alarm(ISensor sensor)
        {
            _sensor = sensor;
        }

        public void Check()
        {
            double psiPressureValue = GetPressure();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                _alarmOn = true;
                _alarmCount += 1;
            }
        }

        protected virtual double GetPressure()
        {
            return _sensor.PopNextPressurePsiValue();
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }
    }
}
