using Microsoft.Extensions.Options;
using NUnit.Framework;
using System.Net.Http;
using WeatherStation.Controllers;

namespace WeatherStationTest
{
    [TestFixture]
    public class WeatherChecker
    {
        private readonly IOptions<AppOptions> _options;

        [Test]
        public void FindWeather()
        {
           
            var controller = new WeatherController(_options);


            // Act
            var response = controller.FindWeather("chennai", "city");

            // Assert
            OpenWeatherResponse weatherResponse=null;
            
            Assert.AreEqual("chennai", weatherResponse.Name);


        }
    }
}