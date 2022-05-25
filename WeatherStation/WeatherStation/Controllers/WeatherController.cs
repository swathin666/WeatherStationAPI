using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using WeatherStation.Models;
using DocumentFormat.OpenXml.Spreadsheet;

namespace WeatherStation.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class WeatherController : Controller
    {
        private readonly IOptions<AppOptions> _options;

        public WeatherController(IOptions<AppOptions> options)
        {
            _options = options;
        }

       [Authorize]
        [HttpGet("[action]/{weatherparameter}")]
       
        public async Task<IActionResult> FindWeather(string weatherparameter,string weatherparametertype)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://api.openweathermap.org");
                    var response = await client.GetAsync($"/data/2.5/weather?q={weatherparameter}&appid={_options.Value.OpenWeatherApiKey}&units=metric");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawWeather = JsonConvert.DeserializeObject<OpenWeatherResponse>(stringResult);
                    return Ok(new
                    {
                        Temp = rawWeather.Main.Temp,
                        Summary = string.Join(",", rawWeather.Weather.Select(x => x.Main)),
                        City = rawWeather.Name
                    });
                }
                catch (System.Net.Http.HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
                }
            }
        }
    }
 



 

}

