using System;
using System.Collections.Generic;
using System.Linq;
using LifetimesTest.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LifetimesTest.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries =
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<WeatherForecastController> _logger;
		private readonly IIntermediateManager _intermediateManager;
		private readonly IIdentificationManager _identificationManager;

		public WeatherForecastController(IIntermediateManager intermediateManager, IIdentificationManager identificationManager,
			ILogger<WeatherForecastController> logger)
		{
			logger.LogInformation("Creating new WeatherForecastController");
			_identificationManager = identificationManager;
			_logger = logger;
			_intermediateManager = intermediateManager;
		}

		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			_logger.LogInformation($"Controller Id is {_identificationManager.Id}");
			_intermediateManager.DoSomething();

			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
				{
					Date = DateTime.Now.AddDays(index),
					TemperatureC = rng.Next(-20, 55),
					Summary = Summaries[rng.Next(Summaries.Length)]
				})
				.ToArray();
		}
	}
}