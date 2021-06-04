using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class AlarmTest
    {

        [Fact]
        public void TestAlarmOnSensorValue0()
        {
            SensorStub st = new SensorStub(0);

            Alarm alarm = new Alarm(st);
            Assert.False(alarm.AlarmOn);
        }


    }

    class SensorStub : ISensor
    {
        public double Value { get; set; }

        public SensorStub(double value)
        {
            Value = value;
        }

        public double PopNextPressurePsiValue()
        {
            return Value;
        }
    }
}