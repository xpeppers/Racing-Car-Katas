using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class AlarmTest
    {
        [Fact]
        public void Alarm_Start_Off()
        {
            Alarm alarm = new Alarm();
            Assert.False(alarm.AlarmOn);
        }

        [Fact]
        public void Check_Alarm_On_below_threshold()
        {
            TestAlarm alarm = new TestAlarm(15.8);
            alarm.Check();

            Assert.True(alarm.AlarmOn);
        }

        [Fact]
        public void Check_Alarm_Off_pressure_into_range()
        {
            TestAlarm alarm = new TestAlarm(20.7);
            alarm.Check();

            Assert.False(alarm.AlarmOn);
        }
    }

    public class TestAlarm : Alarm
    {
        private double _fixedPressure;

        public TestAlarm(double fixedPressure)
        {
            this._fixedPressure = fixedPressure;
        }
        protected override double GetPressure()
        {
            return _fixedPressure;
        }      
    }
}