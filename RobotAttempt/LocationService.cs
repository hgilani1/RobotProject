using System;
using Microsoft.AspNetCore.Mvc;
using RobotAttempt.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.IO;
using System.Text.Json;

namespace RobotAttempt
{
	public class LocationService
	{
		private readonly ILogger<LocationService> _logger;
		private readonly HttpClient _client;


		public LocationService( HttpClient client) // IConfiguration config, ILogger<LocationService> logger)
		{
			//_logger = logger;
            //_logger.LogCritical(new EventId(), null, "Created Service");
            _client = client;
			client.DefaultRequestHeaders.Add("User-Agent", "C# App");
            //var section = config.GetSection("HttpCustomerHeaders:User-agent");
            //_logger.LogCritical(section.Key + ":" + section.Value);
            //_client.DefaultRequestHeaders.Add(section.Key, section.Value);
        }

		public async Task<string> GetNearestLocationOfWater(Location location) // CancellationToken token) 
		{
			//HttpClient clint = new HttpClient();

			HttpResponseMessage httpresponse = await _client.GetAsync($"https://nominatim.openstreetmap.org/search.php?q=water+near+{location.Name}&format=jsonv2");
			return await httpresponse.Content.ReadAsStringAsync();


            //string JsonObjectString = await httpresponse.Content.ReadAsStringAsync();

            //         return JsonSerializer.Deserialize<WaterData[]>(JsonObjectString);

        }
	}
}

