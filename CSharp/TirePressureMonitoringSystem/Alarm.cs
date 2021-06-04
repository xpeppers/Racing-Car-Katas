namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        ISensor _sensor;

        public Alarm(ISensor sensor)
        {
            _sensor = sensor;
        }

        bool _alarmOn = false;

        public void Check()
        {
            double psiPressureValue = RetrieveSensorValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                SetAlarm(true);
            }
        }

        private void SetAlarm(bool value)
        {
            _alarmOn = value;
        }

        private double RetrieveSensorValue()
        {
            return _sensor.PopNextPressurePsiValue();
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }
    }
}
