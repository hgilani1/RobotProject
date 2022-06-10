using System;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using RobotAttempt;

namespace RobotAttempt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotController : ControllerBase // Maps a request to a response.
    {
        private readonly ILogger<RobotController> _logger;
        private readonly LocationService _service;
        //private readonly RobotContext _context;

        //private List<Location> _location = new List<Location>()
        //{
        //    new Location()
        //    {
        //        //Name = "Pacific Ocean",
        //        Longitude = 8,
        //        Latitude = 125,
        //    }
        //};

        public RobotController( LocationService service, ILogger<RobotController> logger) //RobotContext context,
        {
            _service = service;
            _logger = logger;
            //_context = context;
            //_logger.LogCritical(new EventId(2, "this is the name"), "Created Controller");
        }

        //[HttpGet(Name = "RobotSpotted")]
        //public string Get()
        //{
        //    return "hello";
        //}

       
        [HttpPost(Name = "RobotSpotted")]
        public async Task<string> Post(Location location) // CancellationToken token)
        {
            //_logger.Log(LogLevel.Information, new EventId(), null, "Finding the nearest water source to" + location.Name);
            string WaterNearby = await _service.GetNearestLocationOfWater(location);
            JsonSerializer.Serialize(WaterNearby);
            WaterData[] ClosestWater = JsonSerializer.Deserialize<WaterData[]>(WaterNearby);
            //return ClosestWater[0].display_name;
               return $"{location.Name}'s closest water source is {ClosestWater[0].display_name}";
        }
    }
}
