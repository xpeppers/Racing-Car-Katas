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
			alarm.Check();
			Assert.True(alarm.AlarmOn);
		}

		[Fact]
		public void TestAlarmOnSensorValue17()
		{
			SensorStub st = new SensorStub(17);

			Alarm alarm = new Alarm(st);
			alarm.Check();
			Assert.False(alarm.AlarmOn);
		}

		[Fact]
		public void TestAlarmOnSensorValue18()
		{
			SensorStub st = new SensorStub(18);
			Alarm alarm = new Alarm(st);
			alarm.Check();
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