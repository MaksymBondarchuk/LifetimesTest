namespace LifetimesTest.Managers
{
	public static class Incrementer
	{
		private static int _value = 0;

		public static int GetValue()
		{
			return _value++;
		}
	}
}