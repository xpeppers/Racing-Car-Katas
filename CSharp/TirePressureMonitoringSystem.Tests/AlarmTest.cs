using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
	public class AlarmTest
	{
		[Theory]
		[InlineData(0, true)]
		[InlineData(17, false)]
		[InlineData(18, false)]
		public void TestAlarm(double value, bool expected)
		{
			SensorStub st = new SensorStub(value);
			Alarm alarm = new Alarm(st);
			alarm.Check();
			Assert.Equal(expected, alarm.AlarmOn);
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