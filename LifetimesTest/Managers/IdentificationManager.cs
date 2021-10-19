using Microsoft.Extensions.Logging;

namespace LifetimesTest.Managers
{
	public class IdentificationManager : IIdentificationManager
	{
		private readonly int _id;

		public IdentificationManager(ILogger<IdentificationManager> logger)
		{
			logger.LogInformation("Creating new IdentificationManager");
			_id = Incrementer.GetValue();
		}

		public int Id => _id;
	}
}