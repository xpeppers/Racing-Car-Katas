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

        [Fact]
        public void Check_Alarm_On_above_threshold()
        {
            TestAlarm alarm = new TestAlarm(21.1);
            alarm.Check();

            Assert.True(alarm.AlarmOn);
        }

        [Fact]
        public void Check_Alarm_Off_pressure_into_range_with_controlled_sensor()
        {
            ISensor testableSensor = new TestableSensor(20.7);

            Alarm alarm = new Alarm(testableSensor);
            alarm.Check();

            Assert.False(alarm.AlarmOn);
        }

        [Fact]
        public void Check_Alarm_On_below_threshold_with_controlled_sensor()
        {
            ISensor testableSensor = new TestableSensor(15.8);

            Alarm alarm = new Alarm(testableSensor);
            alarm.Check();

            Assert.True(alarm.AlarmOn);
        }

        [Fact]
        public void Check_Alarm_On_above_threshold_with_controlled_sensor()
        {
            const double fixedPressure = 21.1d;
            ISensor testableSensor = new TestableSensor(fixedPressure);

            Alarm alarm = new Alarm(testableSensor);
            alarm.Check();

            Assert.True(alarm.AlarmOn);
        }
    }

    internal class TestableSensor : ISensor
    {
        private double fixedPressure;

        public TestableSensor(double fixedPressure)
        {
            this.fixedPressure = fixedPressure;
        }

        public double PopNextPressurePsiValue()
        {
            return this.fixedPressure;
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