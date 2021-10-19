using Microsoft.Extensions.Logging;

namespace LifetimesTest.Managers
{
	public class IntermediateManager : IIntermediateManager
	{
		private readonly IIdentificationManager _identificationManager;
		private readonly ILogger<IntermediateManager> _logger;

		public IntermediateManager(IIdentificationManager identificationManager, ILogger<IntermediateManager> logger)
		{
			logger.LogInformation("Creating new IntermediateManager");
			_identificationManager = identificationManager;
			_logger = logger;
		}

		public void DoSomething()
		{
			_logger.LogInformation($"Manager Id is {_identificationManager.Id}");
		}
	}
}