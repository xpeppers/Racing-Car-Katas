using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class AlarmTest
    {
        [Fact]
        [System.Obsolete]
        public void Alarm_Start_Off()
        {
            Alarm alarm = new Alarm();
            Assert.False(alarm.AlarmOn);
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
}