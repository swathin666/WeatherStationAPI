using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Results;
using WeatherStation.Controllers;


namespace WeatherForecastControllerTests
{
    [TestFixture]
    public class WeatherForecastControllerTests
    {
        private IOptions<AppOptions> _options;
        [SetUp]
        public void SetUp()
        {

            var app = new AppOptions();
            _options = Options.Create(app);
        }
      
        [Test]
        public async System.Threading.Tasks.Task GetWeather_ShouldReturnCorrectSummary()
        {
          
            var controller = new WeatherController(_options);
            var actionResult = await controller.FindWeather("London", "City");
            var objectResult = actionResult as OkObjectResult;
            var propertyInfo = objectResult.Value.GetType().GetProperty("Summary");
            var summary = propertyInfo.GetValue(objectResult.Value, null);
            NUnit.Framework.Assert.AreEqual("Clear", summary);


        }
    }
}